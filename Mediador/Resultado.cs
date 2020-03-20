using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;

namespace Mediador
{
    public class Resultado : Notifiable
    {
        public object Data { get; set; }

        public IEnumerable<string> Validations => this.Notifications.Select(c => c.Message);
       
    }
}
