using ClinicaMedica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaMedica.Domain.Contracts.Services
{
    public interface IAtendimentoService
    {
        void AgendarAtendimento(Atendimento atendimento);
        void AtualizarAtendimento(Atendimento atendimento);
        void ExcluirAtendimento(Atendimento atendimento);
        List<Atendimento> ObterAtendimentos();
        List<Atendimento> ObterAtendimentosCompletos();
        Atendimento ObterAtendimentoPorId(int idAtendimento);
    }
}
