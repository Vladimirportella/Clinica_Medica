using ClinicaMedica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaMedica.Infra.Data.Mappings
{
    public class PacienteMapping : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente");

            builder.HasKey(p => p.IdPaciente);

            builder.Property(p => p.IdPaciente)
                   .HasColumnName("IdPaciente");

            builder.Property(p => p.Nome)
                   .HasColumnName("Nome")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.Cpf)
                   .HasColumnName("CPF")
                   .HasMaxLength(11)
                   .IsRequired();


            builder.Property(p => p.DataNascimento)
                   .HasColumnName("DataNascimento")
                   .IsRequired();


            builder.Property(p => p.Telefone)
                   .HasColumnName("Telefone")
                   .HasMaxLength(20)
                   .IsRequired();


            builder.Property(p => p.Email)
                   .HasColumnName("Email")
                   .HasMaxLength(50)
                   .IsRequired();
        }

    }
}
