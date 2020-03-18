
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mediador.Pipelines
{

    public class VaidacaoRequestsBehavior<TRequest, TResponse> 
                                        : IPipelineBehavior<TRequest, TResponse>
                                        where TRequest: IRequest<TResponse> where TResponse : Resultado
    {
        private readonly IEnumerable<IValidator> _validators;
        public VaidacaoRequestsBehavior(IEnumerable<IValidator<TRequest>> validators)=> _validators = validators;

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Any() ? Errors(failures) : next();
        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var resultado = new Resultado();

            foreach (var failure in failures)
            {
                resultado.AddError(failure.ErrorMessage);
            }

            return Task.FromResult(resultado as TResponse);
        }

    }
}
