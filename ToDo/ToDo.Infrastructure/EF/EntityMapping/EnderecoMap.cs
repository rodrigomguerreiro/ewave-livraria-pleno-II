using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.EF.EntityMapping
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Logradouro)
                .HasColumnName("Logradouro");

            builder.Property(x => x.Bairro)
                .HasColumnName("Bairro");

            builder.Property(x => x.Complemento)
                .HasColumnName("Complemento");

            builder.Property(x => x.Numero)
                .HasColumnName("Numero");

        }
    }
}
