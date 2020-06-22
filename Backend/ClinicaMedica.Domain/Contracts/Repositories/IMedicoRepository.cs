using ClinicaMedica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaMedica.Domain.Contracts.Repositories
{

    public interface IMedicoRepository : IBaseRepository<Medico>
    {
        Medico ObterPorCrm(string crm);
    }
}
