using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.EF.EntityMapping
{
    public class SituacaoLivroMap : IEntityTypeConfiguration<SituacaoLivro>
    {
        public void Configure(EntityTypeBuilder<SituacaoLivro> builder)
        {
            builder.ToTable("Situacaolivro");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao");

            builder.Property(x => x.Ativo)
                .HasColumnName("ativo");
        }
    }
}
