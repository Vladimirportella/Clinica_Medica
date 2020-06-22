using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaMedica.Domain.Entities
{
    public class Atendimento
    {
        public int IdAtendimento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string Local { get; set; }
        public string Observacoes { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }

        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
    }
}
