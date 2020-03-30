using FluentValidation;
using Mediador.Comandos.FazerCompras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mediador.Validacoes
{
    public class FazerComprasValidacaoV2 : AbstractValidator<FazerComprasComando>
    {
       
        public FazerComprasValidacaoV2()
        {
            RuleFor(c => c.Numero).Equal(2).WithMessage("Numero nao pode ser 2 , validacao from FazerComprasValidacaoV2");

        }
    }
}
