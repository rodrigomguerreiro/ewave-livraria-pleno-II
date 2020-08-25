using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.EF.EntityMapping
{
    public class EmprestimoMap : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("Emprestimo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.DataEmprestimo)
                .HasColumnName("DataEmprestimo");

            builder.Property(x => x.DataDevolucao)
                .HasColumnName("DataDevolucao");

            builder.Property(x => x.DataVencimento)
                .HasColumnName("DataVencimento");

            builder.Property(x => x.LivroId)
                .HasColumnName("LivroId");

            builder.HasOne(x => x.Livro)
                .WithOne()
                .HasPrincipalKey<Livro>(x => x.Id)
                .HasForeignKey<Emprestimo>(x => x.LivroId);

            builder.Property(x => x.UsuarioId)
                .HasColumnName("UsuarioId");

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Emprestimos)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
