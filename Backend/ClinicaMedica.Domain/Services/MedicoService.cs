using ClinicaMedica.Domain.Contracts.Repositories;
using ClinicaMedica.Domain.Contracts.Services;
using ClinicaMedica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClinicaMedica.Domain.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public void AtualizarMedico(Medico medico)
        {
            var medicoPorCrm = _medicoRepository.ObterPorCrm(medico.Crm);

            if (medicoPorCrm != null && medicoPorCrm.IdMedico != medico.IdMedico)
            {
                throw new Exception("Erro: O CRM informado já encontra-se cadastrado.");
            }

            _medicoRepository.Alterar(medico);
        }

        public void CadastrarMedico(Medico medico)
        {

            if (_medicoRepository.ObterPorCrm(medico.Crm) != null)
            {
                throw new Exception("Erro: O CRM informado já encontra-se cadastrado.");
            }

            _medicoRepository.Inserir(medico);
        }

        public void ExcluirMedico(Medico medico)
        {
            _medicoRepository.Excluir(medico);
        }

        public Medico ObterMedicoPorId(int idMedico)
        {
            return _medicoRepository.ObterPorId(idMedico);
        }

        public List<Medico> ObterMedicos()
        {
            return _medicoRepository.Consultar();
        }
    }
}
