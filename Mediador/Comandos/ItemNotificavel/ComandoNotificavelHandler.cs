using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediador.Comandos.ItemNotificavel
{
    public class ComandoNotificavelHandler : IRequestHandler<ComandoNotificavel, Resultado>
    {
        public readonly IMediator _mediador;

        private readonly IEnumerable<IValidator> _validators;

        public ComandoNotificavelHandler(IMediator mediador, IEnumerable<IValidator<ComandoNotificavel>> validators)
        {
            _mediador = mediador;
            _validators = validators;
        }

        public Task<Resultado> Handle(ComandoNotificavel request, CancellationToken cancellationToken)
        {
            request._validators = _validators;
            //request.CurrentInstance = request;
            var result = new Resultado();
            request.Validate();


            try
            {
                if (request.Valid)
                {
                    result.Data = true;
                }
                else
                {
                    result.Data = false;
                    result.AddNotificacoes(request.Notifications);
                }
            }
            catch (Exception erro)
            {
                result.Data = false;
                result.AddNotification("ErroFazerCompras", erro.Message);
            }


            return Task.FromResult(result);
        }
    }



  
}
