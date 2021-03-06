﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Mediador.Comandos.CriarUsuario;
using Mediador.Comandos.Exemplo;
using Mediador.Comandos.FazerCompras;
using Mediador.Comandos.ItemNotificavel;
using Mediador.Entidades;
using Mediador.Validacoes;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Mediador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var comando = new CriarUsuarioComando();
            comando.Email = "";
            comando.Nome = "";

            var response = await _mediator.Send(comando);

            if (response.Valid)
            {

                return Ok(response.Data);

               
            }

            return BadRequest(response.Validations);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            var comando = new ExemploComando();
            comando.Numero = id;

            try
            {
                var retorno = await _mediator.Send(comando);
                return Ok(retorno);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        // GET api/values/5
        [HttpGet("Teste")]
        public async Task<ActionResult<string>> Teste()
        {
            var comando = new FazerComprasComando(CommandVersion.V2);
            comando.Numero = 2;

            try
            {
                var retorno = await _mediator.Send(comando);
                return Ok(retorno);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        // GET api/values/5
        [HttpGet("ComandoNotificavel")]
        public async Task<ActionResult<string>> ComandoNotificavel()
        {
            var comando = new ComandoNotificavel();
            comando.FirstPaymentDate = DateTime.MinValue;
            comando.Document = "x";
            try
            {
                var retorno = await _mediator.Send(comando);
                return Ok(retorno);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
