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
    public class MedicoTest
    {
        private AppContext appContext;
        private string endpoint;

        public MedicoTest()
        {
            appContext = new AppContext();
            endpoint = "/api/Medico";
        }

        [Fact]
        public async Task Medico_Post_ReturnsOk()
        {
            var random = new Random();

            var model = new MedicoCadastroModel();
            model.Nome = "Vladimir - Inclusão";
            model.Crm = random.Next(99999999, 999999999).ToString();
            model.Especializacao = "Cardiologia";
           

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            result.Mensagem.Should().Contain("Médico cadastrado com sucesso.");
            result.Medico.Nome.Should().Equals(model.Nome);
            result.Medico.Crm.Should().Equals(model.Crm);
            result.Medico.Especializacao.Should().Equals(model.Especializacao);
           

        }

        [Fact]
        public async Task Medico_Post_ReturnsBadRequest()
        {

            var model = new MedicoCadastroModel();

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Medico_Put_ReturnsOk()
        {
            var random = new Random();

            var model = new MedicoCadastroModel();
            model.Nome = "Vladimir - Inclusão";
            model.Crm = random.Next(99999999, 999999999).ToString();
            model.Especializacao = "Cardiologia";

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            var modelEdicao = new MedicoEdicaoModel();
            modelEdicao.IdMedico = result.Medico.IdMedico;
            modelEdicao.Nome = "Vladimir - Edição";
            modelEdicao.Crm = result.Medico.Crm;
            modelEdicao.Especializacao = result.Medico.Especializacao;

            var requestEdicao = new StringContent(JsonConvert.SerializeObject(modelEdicao),
                Encoding.UTF8, "application/json");

            var responseEdicao = await appContext.Client.PutAsync(endpoint, requestEdicao);

            responseEdicao.StatusCode.Should().Be(HttpStatusCode.OK);

            var resultEdicao = ObterDadosSucesso(responseEdicao);

            resultEdicao.Mensagem.Should().Contain("Médico atualizado com sucesso.");
            resultEdicao.Medico.Nome.Should().Equals(modelEdicao.Nome);

        }

        [Fact]
        public async Task Medico_Put_ReturnsBadRequest()
        {

            var model = new MedicoEdicaoModel();

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PutAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Medico_Delete_ReturnsOk()
        {
            var random = new Random();

            var model = new MedicoCadastroModel();
            model.Nome = "Vladimir - Inclusão";
            model.Crm = random.Next(99999999, 999999999).ToString();
            model.Especializacao = "Cardiologia";

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            var responseExclusao = await appContext.Client.DeleteAsync(endpoint + "/" + result.Medico.IdMedico);

            responseExclusao.StatusCode.Should().Be(HttpStatusCode.OK);

            var resultExclusao = ObterDadosSucesso(responseExclusao);

            resultExclusao.Mensagem.Should().Contain("Médico excluído com sucesso.");
            resultExclusao.Medico.Nome.Should().Equals(model.Nome);
            resultExclusao.Medico.Crm.Should().Equals(model.Crm);
            resultExclusao.Medico.Especializacao.Should().Equals(model.Especializacao);
           

        }

        [Fact]
        public async Task Medico_Delete_ReturnsBadRequest()
        {
            var responseExclusao = await appContext.Client.DeleteAsync(endpoint + "/999999");

            responseExclusao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


        [Fact]
        public async Task Medico_GetAll_ReturnsOk()
        {
            var response = await appContext.Client.GetAsync(endpoint);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Medico_GetById_ReturnsOk()
        {
            var random = new Random();

            var model = new MedicoCadastroModel();
            model.Nome = "Vladimir - Inclusão";
            model.Crm = random.Next(99999999, 999999999).ToString();
            model.Especializacao = "Cardiologia";

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            var responseConsulta = await appContext.Client
                                   .GetAsync(endpoint + "/" + result.Medico.IdMedico);

            responseConsulta.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Medico_GetById_ReturnsBadRequest()
        {
            var responseExclusao = await appContext.Client.GetAsync(endpoint + "/999999");

            responseExclusao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }




        private MedicoSucessoModel ObterDadosSucesso(HttpResponseMessage response)
        {
            var result = string.Empty;
            using (var content = response.Content)
            {
                var r = content.ReadAsStringAsync();
                result += r.Result;

            }

            return JsonConvert.DeserializeObject<MedicoSucessoModel>(result);
        }
    }
}
