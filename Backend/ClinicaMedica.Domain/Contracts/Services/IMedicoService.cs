using ClinicaMedica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaMedica.Domain.Contracts.Services
{
    public interface IMedicoService
    {
        void CadastrarMedico(Medico medico);
        void AtualizarMedico(Medico medico);
        void ExcluirMedico(Medico medico);
        List<Medico> ObterMedicos();
        Medico ObterMedicoPorId(int idMedico);

    }
}
