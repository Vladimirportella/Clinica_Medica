﻿using ClinicaMedica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaMedica.Services.Models
{
    public class PacienteSucessoModel
    {
        public string Mensagem { get; set; }
        public Paciente Paciente { get; set; }
    }
}
