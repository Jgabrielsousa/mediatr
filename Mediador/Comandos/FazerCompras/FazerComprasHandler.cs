﻿using FluentValidation;
using Mediador.Eventos.FazerCompras;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediador.Comandos.FazerCompras
{
    public class FazerComprasHandler : IRequestHandler<FazerComprasComando, Resultado>
    {
        public readonly IMediator _mediador;

        private readonly IEnumerable<IValidator> _validators;

        public FazerComprasHandler(IMediator mediador, IEnumerable<IValidator<FazerComprasComando>> validators)
        {
            _mediador = mediador;
            _validators = validators;
        }
        public Task<Resultado> Handle(FazerComprasComando request, CancellationToken cancellationToken)
        {
            request._validators = _validators;

            var result = new Resultado();
            
            request.Validate();


            try
            {
                if (request.Valid)
                {
                    result.Data = true;
                    _mediador.Publish(new FazerComprasEvento());
                }
                else
                {
                    result.Data = false;
                    result.AddNotificacoes(request.Notifications);
                }
            }
            catch (Exception erro)
            {
                result.Data = false;
                result.AddNotification("ErroFazerCompras", erro.Message);
            }
           
            
            return Task.FromResult(result);
        }
    }











}
