using ClinicaMedica.Domain.Contracts.Repositories;
using ClinicaMedica.Domain.Entities;
using ClinicaMedica.Infra.Data.DataContexts;
using System.Linq;

namespace ClinicaMedica.Infra.Data.Repositories
{
    public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public Paciente ObterPorCpf(string cpf)
        {
            return DataContext.Set<Paciente>()
                              .FirstOrDefault(p => p.Cpf == cpf);
        }
    }
}
