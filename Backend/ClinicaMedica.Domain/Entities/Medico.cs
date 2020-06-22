using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaMedica.Domain.Entities
{
    public class Medico
    {
        public int IdMedico { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public string Especializacao { get; set; }
       
    }
}
