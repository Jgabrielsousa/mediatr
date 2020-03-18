using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediador.Comandos.Logs
{
    public class LogEventos : INotification
    {
        public string Mensagem;
        public LogEventos(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
