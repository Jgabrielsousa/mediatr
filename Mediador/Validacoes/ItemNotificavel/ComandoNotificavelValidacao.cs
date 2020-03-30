using FluentValidation;
using Mediador.Comandos.ItemNotificavel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mediador.Validacoes.ItemNotificavel
{
    public class ComandoNotificavelValidacao :  AbstractValidator<ComandoNotificavel>
    {
        public ComandoNotificavelValidacao()
        {
            RuleFor(c => c.Document).NotEmpty().WithMessage("Documento não está preenchido");
            RuleFor(c => c.Tab).NotEmpty().WithMessage("Tabela não está preenchida");
            RuleFor(c => c.Uuid).NotEmpty().WithMessage("Uuid não está preenchido");
            RuleFor(c => c.InstallmentAmount).GreaterThan(0).WithMessage("Número de parcelas não está preenchido");
            RuleFor(c => c.TotalValue).GreaterThan(0).WithMessage("Valor não está preenchido");
            RuleFor(c => c.FirstPaymentDate).Equal(DateTime.MinValue).WithMessage("Data da primeira parcela não está preenchida");
        }
    }
}
