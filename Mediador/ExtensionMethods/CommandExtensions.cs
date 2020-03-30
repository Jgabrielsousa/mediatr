using FluentValidation;
using FluentValidation.Results;
using Flunt.Notifications;
using Mediador.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediador.ExtensionMethods
{
    public static class CommandExtensions
    {
        public static IList<Notification> ValidateCommand<T,R>(this Command<T,R> command)
        where T : Command<T,R>, new()
        {
            IList<ValidationFailure> erros = null;
            //VERIFY IF THE COMMAND OVERRIDERS THE METHOD THAT RETURNS A SPECIFIC VALIDATION
            AbstractValidator<T> validator = command.GetValidator(command.version);
            var request = command.CurrentInstance();
            if (validator != null)
            {
                //VALIDATES THE VALIDATION VERSION 
                ValidationResult result = validator.Validate(request);
                if (!result.IsValid)
                    erros = result.Errors;
            }
            else {
                //GET ALL THE VALIDATIONS FOR A GIVEN REQUEST
                erros = command._validators
                        .Select(v => v.Validate(request))
                        .SelectMany(c => c.Errors)
                        .Where(f => f != null)
                        .ToList();
            }


            return erros.Select(a => new Notification(a.PropertyName, a.ErrorMessage)).ToList();

        }
    }
}
