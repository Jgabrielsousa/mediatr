using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediador.Comandos.CriarUsuario
{
    public class CriarUsuarioComando : IRequest<Resultado> 
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    
    }
}
