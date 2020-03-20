using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediador.Comandos.FazerCompras
{
    public class FazerComprasComando : IRequest<Resultado>
    {
        public List<string> ListaCompras { get; set; }
    }
}
