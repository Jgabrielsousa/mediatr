using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediador.Comandos.Logs
{
    public class LogEventos1Handler : INotificationHandler<LogEventos>
    {
        public Task Handle(LogEventos notification, CancellationToken cancellationToken)
        {
            string message = notification.Mensagem;
            return Task.FromResult(0);
        }
    }
}
