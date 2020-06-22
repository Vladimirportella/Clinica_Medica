using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaMedica.Services.Models
{
    public class PacienteCadastroModel
    {
        [MinLength(6, ErrorMessage = "Por favor, infome no mínimo {1} caracteres.")]
        [MaxLength(30, ErrorMessage = "Por favor, infome no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, infome o nome do paciente.")]
        public string Nome { get; set; }

        [MaxLength(11, ErrorMessage = "Por favor, infome no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, infome o cpf do paciente.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, infome a data de nascimento do paciente.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, infome o telefone do paciente.")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, infome um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, infome o email do paciente.")]
        public string Email { get; set; }
    }
}
