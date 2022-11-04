using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infraestructure.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Clientes>
    {

        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.ToTable("TB_CLIENTES");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Bairro).HasMaxLength(100)
            .IsRequired();

            builder.HasIndex(a => a.CpfCnpj).IsUnique();

            builder.HasIndex(a => a.Email).IsUnique();


            builder.Property(c => c.Cep).HasMaxLength(20)
            .IsRequired();

            builder.Property(c => c.Cidade).HasMaxLength(40)
            .IsRequired();

            builder.Property(c => c.Estado).HasMaxLength(40)
            .IsRequired();

            builder.Property(c => c.Logradouro).HasMaxLength(40)
            .IsRequired();

            builder.Property(c => c.Numero).HasMaxLength(10)
            .IsRequired();

            builder.Property(c => c.CpfCnpj).HasMaxLength(30)
            .IsRequired();

            builder.Property(c => c.DataNascimento)
            .IsRequired();


            builder.Property(c => c.TipoPessoa).HasMaxLength(20)
            .IsRequired();

            builder.Property(c => c.InscricaoEstadual).HasMaxLength(50);


            builder.Property(c => c.Email).HasMaxLength(40)
            .IsRequired();

            builder.Property(c => c.Nome).HasMaxLength(50)

            .IsRequired();

            builder.Property(c => c.Telefone).HasMaxLength(25)
            .IsRequired();

        }

    }
}