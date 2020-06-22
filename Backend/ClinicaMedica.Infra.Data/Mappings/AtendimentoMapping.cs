using ClinicaMedica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaMedica.Infra.Data.Mappings
{
    public class AtendimentoMapping : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.ToTable("Atendimento");

            builder.HasKey(a => a.IdAtendimento);

            builder.Property(a => a.IdAtendimento)
                   .HasColumnName("IdAtendimento");

            builder.Property(a => a.DataInicio)
                   .HasColumnName("DataInicio")
                   .IsRequired();

            builder.Property(a => a.DataTermino)
                   .HasColumnName("DataTermino")
                   .IsRequired();

            builder.Property(a => a.Local)
                   .HasColumnName("Local")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(a => a.Observacoes)
                   .HasColumnName("Observacoes")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(a => a.IdMedico)
                   .HasColumnName("IdMedico")
                   .IsRequired();

            builder.Property(a => a.IdPaciente)
                   .HasColumnName("IdPaciente")
                   .IsRequired();

            builder.HasOne(a => a.Medico)
                   .WithMany()
                   .HasForeignKey(a => a.IdMedico);

            builder.HasOne(a => a.Paciente)
                   .WithMany()
                   .HasForeignKey(a => a.IdPaciente);
        }
    }
}
