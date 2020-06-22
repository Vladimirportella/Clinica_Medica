using ClinicaMedica.Domain.Contracts.Repositories;
using ClinicaMedica.Domain.Contracts.Services;
using ClinicaMedica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaMedica.Domain.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public void CadastrarPaciente(Paciente paciente) 
        {
            if (_pacienteRepository.ObterPorCpf(paciente.Cpf) != null)
            {
                throw new Exception("Erro: O CPF já encontra-se cadastrado.");
            }
            _pacienteRepository.Inserir(paciente);
        }

        public void AtualizarPaciente(Paciente paciente) 
        {
            var pacientePorCpf = _pacienteRepository.ObterPorCpf(paciente.Cpf);

            if (pacientePorCpf != null && pacientePorCpf.IdPaciente != paciente.IdPaciente)
            {
                throw new Exception("Erro: O CPF já encontra-se cadastrado.");
            }

            _pacienteRepository.Alterar(paciente);
        }

        public void ExcluirPaciente(Paciente paciente)
        {
            _pacienteRepository.Excluir(paciente);
        }

        public List<Paciente> ObterPacientes()
        {
            return _pacienteRepository.Consultar();
        }

        public Paciente ObterPacientePorId(int idPaciente)
        {
            return _pacienteRepository.ObterPorId(idPaciente);
        }
    }
}
