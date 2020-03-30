using FluentValidation;
using Mediador.Comandos.FazerCompras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediador.Validacoes
{
    public class FazerComprasValidacaoV3 : AbstractValidator<FazerComprasComando>
    {
       
        public FazerComprasValidacaoV3()
        {
            RuleFor(c => c.Numero).Equal(3).WithMessage("Numero nao pode ser 3 , validacao from FazerComprasValidacaoV3");
        }
    }
}
