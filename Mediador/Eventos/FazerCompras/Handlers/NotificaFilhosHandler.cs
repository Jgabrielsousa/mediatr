using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediador.Eventos.FazerCompras
{
    public class NotificaFilhosHandler : INotificationHandler<FazerComprasEvento>
    {

        public Task Handle(FazerComprasEvento notification, CancellationToken cancellationToken)
        {

            int? teste = 1;

            var result = teste ?? 0;


            return Task.FromResult(result);
        }
    }
}
