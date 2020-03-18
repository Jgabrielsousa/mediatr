using Mediador.Comandos.Logs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediador.Comandos.Exemplo
{
    public class ExemploComandoHandler : IRequestHandler<ExemploComando, Resultado>
    {
        private readonly IMediator _mediator;

        public ExemploComandoHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<Resultado> Handle(ExemploComando request, CancellationToken cancellationToken)
        {
            var result = new Resultado();
            var resposta = request.Numero % 2 == 0 ? "par" : "impar";
            result.Data = resposta;
            this._mediator.Publish(new LogEventos($"o resultado foi {resposta}"));
            return Task.FromResult(result);

        }
    }
}
