using Mediador.Eventos.FazerCompras;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediador.Comandos.FazerCompras
{
    public class FazerComprasHandler : IRequestHandler<FazerComprasComando, Resultado>
    {
        public readonly IMediator _mediador;
        public FazerComprasHandler(IMediator mediador)
        {
            _mediador = mediador;
        }
        public Task<Resultado> Handle(FazerComprasComando request, CancellationToken cancellationToken)
        {
            
            var result = new Resultado();
            try
            {
                result.Data = true;
                _mediador.Publish(new FazerComprasEvento());

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
