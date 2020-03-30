using FluentValidation;
using Mediador.Validacoes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediador.Comandos.FazerCompras
{
    public class FazerComprasComando : Command<FazerComprasComando, Resultado>
    {
        public List<string> ListaCompras { get; set; }

        public int Numero { get; set; }

        public FazerComprasComando() : this(CommandVersion.V2){}

        public FazerComprasComando(CommandVersion version) : base(version){}

        public override FazerComprasComando CurrentInstance() => this;

        public override AbstractValidator<FazerComprasComando> GetValidator(CommandVersion version)
        {
            AbstractValidator<FazerComprasComando> validator = null;
            switch (version)
            {
                case CommandVersion.V2: validator = new FazerComprasValidacaoV2(); break;
                case CommandVersion.V3: validator = new FazerComprasValidacaoV3(); break;
                default: validator = new FazerComprasValidacaoV2(); break;
            };

            return validator;
        }


    }
}
