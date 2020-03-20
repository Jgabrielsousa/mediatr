using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediador.Eventos.FazerCompras
{
    public class FazerComprasEvento : INotification
    {
        public bool ComprasEfetuadas { get; set; }
    }
}
