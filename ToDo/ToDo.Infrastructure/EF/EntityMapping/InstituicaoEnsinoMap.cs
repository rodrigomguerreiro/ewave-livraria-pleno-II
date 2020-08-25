using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.EF.EntityMapping
{
    public class InstituicaoEnsinoMap : IEntityTypeConfiguration<InstituicaoEnsino>
    {
        public void Configure(EntityTypeBuilder<InstituicaoEnsino> builder)
        {
            builder.ToTable("InstituicaoEnsino");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome");

            builder.Property(x => x.Cnpj)
                .HasColumnName("Cnpj");

            builder.Property(x => x.Telefone)
                .HasColumnName("Telefone");

            builder.Property(x => x.Ativo)
                .HasColumnName("ativo");

            builder.Property(x => x.EnderecoId)
                .HasColumnName("EnderecoId");

            builder.HasOne(x => x.Endereco)
                .WithOne()
                .HasPrincipalKey<Endereco>(x => x.Id)
                .HasForeignKey<InstituicaoEnsino>(x => x.EnderecoId);

        }
    }
}
