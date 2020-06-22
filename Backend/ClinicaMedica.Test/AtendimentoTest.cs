using ClinicaMedica.Services.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClinicaMedica.Test
{
    public class AtendimentoTest
    {
        private AppContext appContext;
        private string endpoint;

        public AtendimentoTest()
        {
            appContext = new AppContext();
            endpoint = "/api/Atendimento";
        }

        [Fact]
        public async Task Atendimento_Post_ReturnsOk()
        {
            var random = new Random();

            var model = new AtendimentoCadastroModel();
            var ano = random.Next(2021, 2999);
            var mes = random.Next(1, 12);
            var dia = random.Next(1, 30);
            model.DataInicio = new DateTime(ano , mes, dia, 10, 00, 00);
            model.DataTermino = new DateTime(ano, mes, dia, 11, 00, 00);
            model.Local = "Rj";
            model.Observacoes = "INCLUSAO";
            model.IdMedico = 1;
            model.IdPaciente = 1;

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            result.Mensagem.Should().Contain("Atendimento agendado com sucesso.");
            result.Atendimento.DataInicio.Should().Equals(model.DataInicio);
            result.Atendimento.DataTermino.Should().Equals(model.DataTermino);
            result.Atendimento.Local.Should().Equals(model.Local);
            result.Atendimento.Observacoes.Should().Equals(model.Observacoes);
            result.Atendimento.IdMedico.Should().Equals(model.IdMedico);
            result.Atendimento.IdPaciente.Should().Equals(model.IdPaciente);


        }

        [Fact]
        public async Task Atendimento_Post_ReturnsBadRequest()
        {

            var model = new AtendimentoCadastroModel();

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Atendimento_Put_ReturnsOk()
        {
            var random = new Random();

            var model = new AtendimentoCadastroModel();
            var ano = random.Next(2021, 2999);
            var mes = random.Next(1, 12);
            var dia = random.Next(1, 30);
            model.DataInicio = new DateTime(ano, mes, dia, 10, 00, 00);
            model.DataTermino = new DateTime(ano, mes, dia, 11, 00, 00);
            model.Local = "Rj";
            model.Observacoes = "INCLUSAO";
            model.IdMedico = 1;
            model.IdPaciente = 1;

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            var modelEdicao = new AtendimentoEdicaoModel();
            modelEdicao.IdAtendimento = result.Atendimento.IdAtendimento;
            modelEdicao.DataInicio = result.Atendimento.DataInicio;
            modelEdicao.DataTermino = result.Atendimento.DataTermino;
            modelEdicao.Local = result.Atendimento.Local;
            modelEdicao.Observacoes = "EDICAO";
            modelEdicao.IdMedico = result.Atendimento.IdMedico;
            modelEdicao.IdPaciente = result.Atendimento.IdPaciente;
            

            var requestEdicao = new StringContent(JsonConvert.SerializeObject(modelEdicao),
                Encoding.UTF8, "application/json");

            var responseEdicao = await appContext.Client.PutAsync(endpoint, requestEdicao);

            responseEdicao.StatusCode.Should().Be(HttpStatusCode.OK);

            var resultEdicao = ObterDadosSucesso(responseEdicao);

            resultEdicao.Mensagem.Should().Contain("Atendimento atualizado com sucesso.");
            resultEdicao.Atendimento.Observacoes.Should().Equals(modelEdicao.Observacoes);

        }

        [Fact]
        public async Task Atendimento_Put_ReturnsBadRequest()
        {

            var model = new AtendimentoEdicaoModel();

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PutAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Atendimento_Delete_ReturnsOk()
        {
            var random = new Random();

            var model = new AtendimentoCadastroModel();

            var ano = random.Next(2021, 2999);
            var mes = random.Next(1, 12);
            var dia = random.Next(1, 30);
            model.DataInicio = new DateTime(ano, mes, dia, 10, 00, 00);
            model.DataTermino = new DateTime(ano, mes, dia, 11, 00, 00);
            model.Local = "Rj";
            model.Observacoes = "INCLUSAO";
            model.IdMedico = 1;
            model.IdPaciente = 1;

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            var responseExclusao = await appContext.Client.DeleteAsync(endpoint + "/" + result.Atendimento.IdAtendimento);

            responseExclusao.StatusCode.Should().Be(HttpStatusCode.OK);

            var resultExclusao = ObterDadosSucesso(responseExclusao);

            resultExclusao.Mensagem.Should().Contain("Atendimento excluído com sucesso.");
            resultExclusao.Atendimento.DataInicio.Should().Equals(model.DataTermino);
            resultExclusao.Atendimento.DataTermino.Should().Equals(model.DataTermino);
            resultExclusao.Atendimento.Local.Should().Equals(model.Local);
            resultExclusao.Atendimento.Observacoes.Should().Equals(model.Observacoes);
            resultExclusao.Atendimento.IdMedico.Should().Equals(model.IdMedico);
            resultExclusao.Atendimento.IdPaciente.Should().Equals(model.IdPaciente);


        }

        [Fact]
        public async Task Atendimento_Delete_ReturnsBadRequest()
        {
            var responseExclusao = await appContext.Client.DeleteAsync(endpoint + "/999999");

            responseExclusao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


        [Fact]
        public async Task Atendimento_GetAll_ReturnsOk()
        {
            var response = await appContext.Client.GetAsync(endpoint);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Atendimento_GetById_ReturnsOk()
        {
            var random = new Random();

            var model = new AtendimentoCadastroModel();
            var ano = random.Next(2021, 2999);
            var mes = random.Next(1, 12);
            var dia = random.Next(1, 30);
            model.DataInicio = new DateTime(ano, mes, dia, 10, 00, 00);
            model.DataTermino = new DateTime(ano, mes, dia, 11, 00, 00);
            model.Local = "Rj";
            model.Observacoes = "INCLUSAO";
            model.IdMedico = 1;
            model.IdPaciente = 1;

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            var responseConsulta = await appContext.Client
                                   .GetAsync(endpoint + "/" + result.Atendimento.IdAtendimento);

            responseConsulta.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Atendimento_GetById_ReturnsBadRequest()
        {
            var responseExclusao = await appContext.Client.GetAsync(endpoint + "/999999");

            responseExclusao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }




        private AtendimentoSucessoModel ObterDadosSucesso(HttpResponseMessage response)
        {
            var result = string.Empty;
            using (var content = response.Content)
            {
                var r = content.ReadAsStringAsync();
                result += r.Result;

            }

            return JsonConvert.DeserializeObject<AtendimentoSucessoModel>(result);
        }
    }
}
