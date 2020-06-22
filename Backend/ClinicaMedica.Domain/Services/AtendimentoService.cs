using ClinicaMedica.Domain.Contracts.Repositories;
using ClinicaMedica.Domain.Contracts.Services;
using ClinicaMedica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaMedica.Domain.Services
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IAtendimentoRepository _atendimentoRepository;

        public AtendimentoService(IAtendimentoRepository atendimentoRepository)
        {
            _atendimentoRepository = atendimentoRepository;
        }

        public void AtualizarAtendimento(Atendimento atendimento)
        {

            var atendimentos = _atendimentoRepository.Consultar();

            if (atendimentos != null)
            {
                foreach (var item in atendimentos)
                {
                    if (item.IdAtendimento != atendimento.IdAtendimento)
                    {
                        if (item.IdMedico == atendimento.IdMedico)
                        {
                            if (atendimento.DataInicio <= item.DataTermino && atendimento.DataTermino >= item.DataInicio)
                            {
                                throw new Exception("Não é possível realizar o agendamento, " +
                                               "o médico já possui outro atendimento nesse horário.");
                            }

                        }

                        if (item.IdPaciente == atendimento.IdPaciente)
                        {
                            if (atendimento.DataInicio <= item.DataTermino && atendimento.DataTermino >= item.DataInicio)
                            {
                                throw new Exception("Não é possível realizar o agendamento, " +
                                               "o paciente já possui outro atendimento nesse horário.");
                            }

                        }
                    }
                    
                }

            }
            _atendimentoRepository.Alterar(atendimento);
        }

        public void AgendarAtendimento(Atendimento atendimento)
        {
            if (atendimento.DataInicio < DateTime.Now)
            {
                throw new Exception("Essa data não é válida.");
            }

            var atendimentos = _atendimentoRepository.Consultar();

            if (atendimentos != null)
            {
                foreach (var item in atendimentos)
                {
                    if (item.IdMedico == atendimento.IdMedico)
                    {
                        if (atendimento.DataInicio <= item.DataTermino && atendimento.DataTermino >= item.DataInicio)
                        {
                            throw new Exception("Não é possível realizar o agendamento, " +
                                           "o médico já possui outro atendimento nesse horário.");
                        }
   
                    }

                    if (item.IdPaciente == atendimento.IdPaciente)
                    {
                        if (atendimento.DataInicio <= item.DataTermino && atendimento.DataTermino >= item.DataInicio)
                        {
                            throw new Exception("Não é possível realizar o agendamento, " +
                                           "o paciente já possui outro atendimento nesse horário.");
                        }
                    }
                }
               
            }

            _atendimentoRepository.Inserir(atendimento);

        }

        public void ExcluirAtendimento(Atendimento atendimento)
        {
            _atendimentoRepository.Excluir(atendimento);
        }

        public Atendimento ObterAtendimentoPorId(int idAtendimento)
        {
            return _atendimentoRepository.ObterPorId(idAtendimento);
        }

        public List<Atendimento> ObterAtendimentos()
        {
            return _atendimentoRepository.Consultar();
        }

        public List<Atendimento> ObterAtendimentosCompletos()
        {
            return _atendimentoRepository.ConsultarAtendimentosCompletos();
        }
    }
}
