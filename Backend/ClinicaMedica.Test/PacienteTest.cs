using ClinicaMedica.Services.Models;
using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
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
    public class PacienteTest
    {
        private AppContext appContext;
        private string endpoint;

        public PacienteTest()
        {
            appContext = new AppContext();
            endpoint = "/api/Paciente";
        }

        [Fact]
        public async Task Paciente_Post_ReturnsOk() 
        {
            var random = new Random();

            var model = new PacienteCadastroModel();
            model.Nome = "Vladimir - Inclusão";
            model.Cpf = random.Next(99999999, 999999999).ToString();
            model.DataNascimento = new DateTime(1994, 10, 25);
            model.Telefone = "981373216";
            model.Email = $"vladimir{random.Next(99, 9999)}@gmail.com";

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            result.Mensagem.Should().Contain("Paciente cadastrado com sucesso.");
            result.Paciente.Nome.Should().Equals(model.Nome);
            result.Paciente.Cpf.Should().Equals(model.Cpf);
            result.Paciente.DataNascimento.Should().Equals(model.DataNascimento);
            result.Paciente.Telefone.Should().Equals(model.Telefone);
            result.Paciente.Email.Should().Equals(model.Email);
            
        }

        [Fact]
        public async Task Paciente_Post_ReturnsBadRequest()
        {

            var model = new PacienteCadastroModel();

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Paciente_Put_ReturnsOk()
        {
            var random = new Random();

            var model = new PacienteCadastroModel();
            model.Nome = "Vladimir - Inclusão";
            model.Cpf = random.Next(99999999, 999999999).ToString();
            model.DataNascimento = new DateTime(1994, 10, 25);
            model.Telefone = "981373216";
            model.Email = $"vladimir{random.Next(99, 9999)}@gmail.com";

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            var modelEdicao = new PacienteEdicaoModel();
            modelEdicao.IdPaciente = result.Paciente.IdPaciente;
            modelEdicao.Nome = "Vladimir - Edição";
            modelEdicao.Cpf = result.Paciente.Cpf;
            modelEdicao.DataNascimento = result.Paciente.DataNascimento;
            modelEdicao.Telefone = result.Paciente.Telefone;
            modelEdicao.Email = result.Paciente.Email;

            var requestEdicao = new StringContent(JsonConvert.SerializeObject(modelEdicao),
                Encoding.UTF8, "application/json");

            var responseEdicao = await appContext.Client.PutAsync(endpoint, requestEdicao);

            responseEdicao.StatusCode.Should().Be(HttpStatusCode.OK);

            var resultEdicao = ObterDadosSucesso(responseEdicao);

            resultEdicao.Mensagem.Should().Contain("Paciente atualizado com sucesso.");
            resultEdicao.Paciente.Nome.Should().Equals(modelEdicao.Nome);

        }

        [Fact]
        public async Task Paciente_Put_ReturnsBadRequest()
        {

            var model = new PacienteEdicaoModel();

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PutAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Paciente_Delete_ReturnsOk()
        {
            var random = new Random();

            var model = new PacienteCadastroModel();
            model.Nome = "Vladimir - Inclusão";
            model.Cpf = random.Next(99999999, 999999999).ToString();
            model.DataNascimento = new DateTime(1994, 10, 25);
            model.Telefone = "981373216";
            model.Email = $"vladimir{random.Next(99, 9999)}@gmail.com";

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            var responseExclusao = await appContext.Client.DeleteAsync(endpoint + "/" + result.Paciente.IdPaciente);

            responseExclusao.StatusCode.Should().Be(HttpStatusCode.OK);

            var resultExclusao = ObterDadosSucesso(responseExclusao);

            resultExclusao.Mensagem.Should().Contain("Paciente excluído com sucesso.");
            resultExclusao.Paciente.Nome.Should().Equals(model.Nome);
            resultExclusao.Paciente.Cpf.Should().Equals(model.Cpf);
            resultExclusao.Paciente.DataNascimento.Should().Equals(model.DataNascimento);
            resultExclusao.Paciente.Telefone.Should().Equals(model.Telefone);
            resultExclusao.Paciente.Email.Should().Equals(model.Email);

        }

        [Fact]
        public async Task Paciente_Delete_ReturnsBadRequest()
        {
            var responseExclusao = await appContext.Client.DeleteAsync(endpoint + "/999999");

            responseExclusao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


        [Fact]
        public async Task Paciente_GetAll_ReturnsOk() 
        {
            var response = await appContext.Client.GetAsync(endpoint);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Paciente_GetById_ReturnsOk()
        {
            var random = new Random();

            var model = new PacienteCadastroModel();
            model.Nome = "Vladimir - Inclusão";
            model.Cpf = random.Next(99999999, 999999999).ToString();
            model.DataNascimento = new DateTime(1994, 10, 25);
            model.Telefone = "981373216";
            model.Email = $"vladimir{random.Next(99, 9999)}@gmail.com";

            var request = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            var responseConsulta = await appContext.Client
                                   .GetAsync(endpoint + "/" + result.Paciente.IdPaciente);

            responseConsulta.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Paciente_GetById_ReturnsBadRequest()
        {
            var responseExclusao = await appContext.Client.GetAsync(endpoint + "/999999");

            responseExclusao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }




        private PacienteSucessoModel ObterDadosSucesso(HttpResponseMessage response) 
        {
            var result = string.Empty;
            using(var content = response.Content) 
            {
                var r = content.ReadAsStringAsync();
                result += r.Result;
                    
            }

            return JsonConvert.DeserializeObject<PacienteSucessoModel>(result);
        }
    }
}
