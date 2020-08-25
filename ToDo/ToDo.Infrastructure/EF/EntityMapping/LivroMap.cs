using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.EF.EntityMapping
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder
                .ToTable("Livro");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Titulo)
                .HasColumnName("Titulo");

            builder
                .Property(x => x.Sinopse)
                .HasColumnName("Sinopse");

            builder
                .Property(x => x.Capa)
                .HasColumnName("Capa");

            builder.Property(x => x.Ativo)
                .HasColumnName("ativo");

            builder
                .Property(x => x.SituacaoLivroId)
                .HasColumnName("SituacaoLivroId");

            builder
                .HasOne(x => x.SituacaoLivro)
                .WithOne()
                .HasPrincipalKey<SituacaoLivro>(x => x.Id)
                .HasForeignKey<Livro>(x => x.SituacaoLivroId);

            builder
                .HasOne(x => x.Autor)
                .WithMany()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.AutorId);

            builder
                .HasOne(x => x.Genero)
                .WithMany()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.GeneroId);
        }
    }
}
