using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaMedica.Domain.Contracts.Repositories;
using ClinicaMedica.Domain.Contracts.Services;
using ClinicaMedica.Domain.Services;
using ClinicaMedica.Infra.Data.DataContexts;
using ClinicaMedica.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ClinicaMedica.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IPacienteService, PacienteService>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IMedicoService, MedicoService>();
            services.AddTransient<IMedicoRepository, MedicoRepository>();
            services.AddTransient<IAtendimentoService, AtendimentoService>();
            services.AddTransient<IAtendimentoRepository, AtendimentoRepository>();

            #region swagger

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Sistema de Controle de Atendimentos",
                        Description = "API Rest para integração com serviços de " +
                                      "uma clínica médica.",
                        Version = "v1"

                    });
                });

            #endregion

            #region Cors

            services.AddCors(
                c => c.AddPolicy("DefaultPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    }));

            #endregion

            #region Entity Framework

            services.AddDbContext<DataContext>
                    (options => options.UseSqlServer
                    (Configuration.GetConnectionString("Projeto")));

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region swagger

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto API");
            });

            #endregion

            #region Cors

            app.UseCors("DefaultPolicy");

            #endregion

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
