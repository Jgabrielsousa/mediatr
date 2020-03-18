using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediador.Comandos.Exemplo
{
    public class ExemploComando : IRequest<Resultado>
    {
        public int Numero { get; set; }
    }
}
