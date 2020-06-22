using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaMedica.Domain.Contracts.Services;
using ClinicaMedica.Domain.Entities;
using ClinicaMedica.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaMedica.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAtendimentoService _atendimentoService;

        public AtendimentoController(IAtendimentoService atendimentoService)
        {
            _atendimentoService = atendimentoService;
        }

        [HttpPost]
        public IActionResult Post(AtendimentoCadastroModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var atendimento = new Atendimento();
                atendimento.DataInicio = model.DataInicio;
                atendimento.DataTermino = model.DataTermino;
                atendimento.Local = model.Local;
                atendimento.Observacoes = model.Observacoes;
                atendimento.IdMedico = model.IdMedico;
                atendimento.IdPaciente = model.IdPaciente;

                _atendimentoService.AgendarAtendimento(atendimento);

                var result = new AtendimentoSucessoModel();
                result.Mensagem = "Atendimento agendado com sucesso.";
                result.Atendimento = atendimento;

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpPut]
        public IActionResult Put(AtendimentoEdicaoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var atendimento = _atendimentoService.ObterAtendimentoPorId(model.IdAtendimento);

            if (atendimento == null)
            {
                return BadRequest("Atendimento não encontrado.");
            }

            try
            {

                atendimento.DataInicio = model.DataInicio;
                atendimento.DataTermino = model.DataTermino;
                atendimento.Local = model.Local;
                atendimento.Observacoes = model.Observacoes;
                atendimento.IdMedico = model.IdMedico;
                atendimento.IdPaciente = model.IdPaciente;

                _atendimentoService.AtualizarAtendimento(atendimento);

                var result = new AtendimentoSucessoModel();
                result.Mensagem = "Atendimento atualizado com sucesso.";
                result.Atendimento = atendimento;

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var atendimento = _atendimentoService.ObterAtendimentoPorId(id);

            if (atendimento == null)
            {
                return BadRequest("Atendimento não encontrado.");
            }

            try
            {
                _atendimentoService.ExcluirAtendimento(atendimento);

                var result = new AtendimentoSucessoModel();
                result.Mensagem = "Atendimento excluído com sucesso.";
                result.Atendimento = atendimento;

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_atendimentoService.ObterAtendimentosCompletos());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var atendimento = _atendimentoService.ObterAtendimentoPorId(id);

            if (atendimento == null)
            {
                return BadRequest("Atendimento não encontrado.");
            }

            try
            {
                return Ok(atendimento);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}