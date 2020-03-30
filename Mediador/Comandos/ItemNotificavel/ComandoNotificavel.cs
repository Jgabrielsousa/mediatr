using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using System;

namespace Mediador.Comandos.ItemNotificavel
{
  

    /// <summary>
    /// SIMULANDO O SimulationCommand LOAN
    /// </summary>
    public class ComandoNotificavel : Command<ComandoNotificavel, Resultado>
    {

        public ComandoNotificavel()
        {

        }
        public string Document { get; set; }
        public DateTime FirstPaymentDate { get; set; }
        public int InstallmentAmount { get; set; }
        public int TotalValue { get; set; }
        public string SourceChannel { get; set; }
        public string Tab { get; set; }
        public string Uuid { get; set; }

        public override ComandoNotificavel CurrentInstance() => this;
    }
}
