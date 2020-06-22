using ClinicaMedica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ClinicaMedica.Services.Models
{
    public class AtendimentoSucessoModel
    {
        public string Mensagem { get; set; }
        public Atendimento Atendimento { get; set; }
    }
}
