using ClinicaMedica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaMedica.Domain.Contracts.Repositories
{
    public interface IPacienteRepository : IBaseRepository<Paciente>
    {
        Paciente ObterPorCpf(string cpf);
    }
}
