using ClinicaMedica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaMedica.Infra.Data.Mappings
{
    public class MedicoMapping : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medico");

            builder.HasKey(m => m.IdMedico);

            builder.Property(m => m.IdMedico).HasColumnName("IdMedico");

            builder.Property(m => m.Nome)
                   .HasColumnName("Nome")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(m => m.Crm)
                   .HasColumnName("CRM")
                   .HasMaxLength(15)
                   .IsRequired();

            builder.Property(m => m.Especializacao)
                   .HasColumnName("Especializacao")
                   .HasMaxLength(100)
                   .IsRequired();

            
        }
    }
}
