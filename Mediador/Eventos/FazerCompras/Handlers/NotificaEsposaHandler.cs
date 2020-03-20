using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediador.Eventos.FazerCompras
{
    public class NotificaEsposaHandler : INotificationHandler<FazerComprasEvento>
    {
        public NotificaEsposaHandler()
        {

        }
        public Task Handle(FazerComprasEvento notification, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}
