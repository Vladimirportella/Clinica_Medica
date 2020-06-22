using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaMedica.Domain.Contracts.Services;
using ClinicaMedica.Domain.Entities;
using ClinicaMedica.Services.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaMedica.Services.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpPost]
        public IActionResult Post(PacienteCadastroModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var paciente = new Paciente();
                paciente.Nome = model.Nome;
                paciente.Cpf = model.Cpf;
                paciente.DataNascimento = model.DataNascimento;
                paciente.Telefone = model.Telefone;
                paciente.Email = model.Email;

                _pacienteService.CadastrarPaciente(paciente);

                var result = new PacienteSucessoModel();
                result.Mensagem = "Paciente cadastrado com sucesso.";
                result.Paciente = paciente;

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpPut]
        public IActionResult Put(PacienteEdicaoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var paciente = _pacienteService.ObterPacientePorId(model.IdPaciente);

            if (paciente == null)
            {
                return BadRequest("Paciente não encontrado.");
            }

            try
            {

                
                paciente.Nome = model.Nome;
                paciente.Cpf = model.Cpf;
                paciente.DataNascimento = model.DataNascimento;
                paciente.Telefone = model.Telefone;
                paciente.Email = model.Email;

                _pacienteService.AtualizarPaciente(paciente);

                var result = new PacienteSucessoModel();
                result.Mensagem = "Paciente atualizado com sucesso.";
                result.Paciente = paciente;

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
            var paciente = _pacienteService.ObterPacientePorId(id);

            if (paciente == null)
            {
                return BadRequest("Paciente não encontrado.");
            }

            try
            {
                _pacienteService.ExcluirPaciente(paciente);

                var result = new PacienteSucessoModel();
                result.Mensagem = "Paciente excluído com sucesso.";
                result.Paciente = paciente;

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
                return Ok(_pacienteService.ObterPacientes());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var paciente = _pacienteService.ObterPacientePorId(id);

            if (paciente == null)
            {
                return BadRequest("Paciente não encontrado.");
            }

            try
            {
                return Ok(paciente);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}