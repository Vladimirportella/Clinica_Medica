using ClinicaMedica.Domain.Contracts.Repositories;
using ClinicaMedica.Domain.Entities;
using ClinicaMedica.Infra.Data.DataContexts;
using System.Linq;

namespace ClinicaMedica.Infra.Data.Repositories
{
    public class MedicoRepository : BaseRepository<Medico>, IMedicoRepository
    {
        public MedicoRepository(DataContext dataContext) : base(dataContext)
        {
                
        }

        public Medico ObterPorCrm(string crm)
        {
            return DataContext.Set<Medico>()
                              .FirstOrDefault(m => m.Crm == crm);
        }
    }
}
