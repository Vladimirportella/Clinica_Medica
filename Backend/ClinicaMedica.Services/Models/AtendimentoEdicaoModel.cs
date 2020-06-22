using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaMedica.Services.Models
{
    public class AtendimentoEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do Atendimento.")]
        public int IdAtendimento { get; set; }
     
        [Required(ErrorMessage = "Por favor, informe a data e hora do ínicio do atendimento.")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data e hora do término do atendimento.")]
        public DateTime DataTermino { get; set; }

        [Required(ErrorMessage = "Por favor, informe o local do Atendimento.")]
        public string Local { get; set; }

        [Required(ErrorMessage = "Por favor, informe as observações do Atendimento.")]
        public string Observacoes { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id do Médico.")]
        public int IdMedico { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id do Paciente.")]
        public int IdPaciente { get; set; }
    }
}
