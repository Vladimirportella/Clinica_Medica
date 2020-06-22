using ClinicaMedica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaMedica.Domain.Contracts.Services
{
    public interface IPacienteService
    {
        void CadastrarPaciente(Paciente paciente);
        void AtualizarPaciente(Paciente paciente);
        void ExcluirPaciente(Paciente paciente);
        List<Paciente> ObterPacientes();
        Paciente ObterPacientePorId(int idPaciente);
    }
}
