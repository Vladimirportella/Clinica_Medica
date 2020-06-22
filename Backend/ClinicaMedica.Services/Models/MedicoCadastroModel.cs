using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaMedica.Services.Models
{
    public class MedicoCadastroModel
    {
        [MaxLength(30, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do médico.")]
        public string Nome { get; set; }

        [MaxLength(15, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o CRM do médico.")]
        public string Crm { get; set; }

        [Required(ErrorMessage = "Por favor, informe a especialização do médico.")]
        public string Especializacao { get; set; }
    }
}
