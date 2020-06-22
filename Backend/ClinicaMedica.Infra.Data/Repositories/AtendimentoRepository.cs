using ClinicaMedica.Domain.Contracts.Repositories;
using ClinicaMedica.Domain.Entities;
using ClinicaMedica.Infra.Data.DataContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClinicaMedica.Infra.Data.Repositories
{
    public class AtendimentoRepository : BaseRepository<Atendimento>, IAtendimentoRepository
    {
        public AtendimentoRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public List<Atendimento> ConsultarAtendimentosCompletos()
        {
            return DataContext.Set<Atendimento>()
                              .Include(a => a.Paciente)
                              .Include(a => a.Medico).ToList();
        }

       
    }
}
