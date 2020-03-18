using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediador
{
    public class Resultado
    {
        public static Resultado Ok = new Resultado();

        public List<string> Validations = new List<string>();

        public object Data { get; set; }

        public bool isValid { get { return !Validations.Any(); } }

        public void AddError(string erro)
        {
            this.Validations.Add(erro);
        }
    }
}
