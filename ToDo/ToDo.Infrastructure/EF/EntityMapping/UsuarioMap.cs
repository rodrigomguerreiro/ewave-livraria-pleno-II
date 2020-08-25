using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.EF.EntityMapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome");

            builder.Property(x => x.Cpf)
                .HasColumnName("Cpf");

            builder.Property(x => x.Telefone)
                .HasColumnName("Telefone");

            builder.Property(x => x.Email)
                .HasColumnName("Email");

            builder.Property(x => x.Ativo)
                .HasColumnName("ativo");

            builder.Property(x => x.EnderecoId)
                .HasColumnName("EnderecoId");

            builder.HasOne(x => x.Endereco)
                .WithOne()
                .HasPrincipalKey<Endereco>(x => x.Id)
                .HasForeignKey<Usuario>(x => x.EnderecoId);

            builder.Property(x => x.InstituicaoEnsinoId)
                .HasColumnName("InstituicaoEnsinoId");

            builder.HasOne(x => x.InstituicaoEnsino)
                .WithOne()
                .HasPrincipalKey<InstituicaoEnsino>(x => x.Id)
                .HasForeignKey<Usuario>(x => x.InstituicaoEnsinoId);
        }
    }
}
