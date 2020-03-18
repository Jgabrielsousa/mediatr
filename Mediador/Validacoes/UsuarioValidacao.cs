using FluentValidation;
using Mediador.Comandos.CriarUsuario;
using Mediador.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediador.Validacoes
{
    public class UsuarioValidacao : AbstractValidator<CriarUsuarioComando>
    {
        public UsuarioValidacao()
        {
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().WithMessage("Por favor email valido");
        }
    }
}
