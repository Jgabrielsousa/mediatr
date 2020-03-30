using FluentValidation;
using FluentValidation.Results;
using Flunt.Notifications;
using Mediador.ExtensionMethods;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediador.Comandos
{
    public abstract class Command<T,R> : Notifiable, IRequest<R>
      where T : Command<T,R>, new()
    {

        public IEnumerable<IValidator> _validators;

        public abstract T CurrentInstance();

        public CommandVersion version { get; set; }

        public Command() :this(CommandVersion.V2)
        {
           
        }
        public Command(CommandVersion version)=> this.version = version;
      
        public virtual AbstractValidator<T> GetValidator(CommandVersion version) => null;



        public void Validate()
        {
            if (Valid)
            {
                var notifications = this.ValidateCommand<T,R>();
                if (notifications != null)
                {
                    AddNotifications(notifications);
                }
            }
        }
    }
}
