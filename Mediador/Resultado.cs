using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Newtonsoft.Json;

namespace Mediador
{
    
    public class Resultado 
    {
        public Resultado() => Notifications = new List<Notification>();

        public object Data { get; set; }
        public bool Valid => !this.Notifications.Any();
        public IEnumerable<string> Validations => this.Notifications.Select(c => c.Message);
       
        [JsonIgnore]
        public IList<Notification> Notifications { get; set; }
       

        #region Methods
        public void AddNotification(string propertyName, string propertyValue) => Notifications.Add(new Notification(propertyName, propertyValue)); 
        public void AddNotificacoes(IReadOnlyCollection<Notification> notifications)
        {
            foreach (var item in notifications)
            {
                Notifications.Add(item);
            }
        }
        #endregion

    }
}
