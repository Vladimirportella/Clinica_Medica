using ClinicaMedica.Domain.Entities;
using ClinicaMedica.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaMedica.Infra.Data.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MedicoMapping());
            modelBuilder.ApplyConfiguration(new AtendimentoMapping());
            modelBuilder.ApplyConfiguration(new PacienteMapping());

            modelBuilder.Entity<Paciente>()
                        .HasIndex(p => p.Cpf)
                        .IsUnique();

            modelBuilder.Entity<Medico>()
                        .HasIndex(m => m.Crm)
                        .IsUnique();
        }

        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }
    }
}
