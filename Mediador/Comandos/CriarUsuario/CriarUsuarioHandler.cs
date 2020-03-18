using FluentValidation.Results;
using Mediador.Entidades;
using Mediador.Validacoes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediador.Comandos.CriarUsuario
{
    public class CriarUsuarioHandler : IRequestHandler<CriarUsuarioComando, Resultado>
    {
        public Task<Resultado> Handle(CriarUsuarioComando request, CancellationToken cancellationToken)
        {
            var resultado = new Resultado();
            //insere o usuario
            var usuario = new Usuario(request.Nome, request.Email);
            resultado.Data = usuario;
            return Task.FromResult(resultado);
        }
    }
}
