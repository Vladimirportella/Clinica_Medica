﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaMedica.Domain.Entities
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

       
    }
}
