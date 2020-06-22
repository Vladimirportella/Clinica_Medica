using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaMedica.Domain.Contracts.Services;
using ClinicaMedica.Domain.Entities;
using ClinicaMedica.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;

namespace ClinicaMedica.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }


        [HttpPost]
        public IActionResult Post(MedicoCadastroModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var medico = new Medico();
                medico.Nome = model.Nome;
                medico.Crm = model.Crm;
                medico.Especializacao = model.Especializacao;

                _medicoService.CadastrarMedico(medico);

                var result = new MedicoSucessoModel();
                result.Mensagem = "Médico cadastrado com sucesso.";
                result.Medico = medico;

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpPut]
        public IActionResult Put(MedicoEdicaoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var medico = _medicoService.ObterMedicoPorId(model.IdMedico);

            if (medico == null)
            {
                return BadRequest("Médico não encontrado.");
            }

            try
            {
           
                medico.Nome = model.Nome;
                medico.Crm = model.Crm;
                medico.Especializacao = model.Especializacao;

                _medicoService.AtualizarMedico(medico);

                var result = new MedicoSucessoModel();
                result.Mensagem = "Médico atualizado com sucesso.";
                result.Medico = medico;

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
            var medico = _medicoService.ObterMedicoPorId(id);

            if (medico == null)
            {
                return BadRequest("Médico não encontrado.");
            }

            try
            {
                _medicoService.ExcluirMedico(medico);

                var result = new MedicoSucessoModel();
                result.Mensagem = "Médico excluído com sucesso.";
                result.Medico = medico;

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
                return Ok(_medicoService.ObterMedicos());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var medico = _medicoService.ObterMedicoPorId(id);

            if (medico == null)
            {
                return BadRequest("Médico não encontrado.");
            }

            try
            {
                return Ok(medico);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}