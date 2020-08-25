using System;
using ToDo.Domain.Repositories;

namespace ToDo.Domain.Entities
{
    public class Emprestimo : IEntity
    {
        public int Id { get; set; }
        public Guid AggregateId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public int LivroId { get; set; }
        public int UsuarioId { get; set; }
        public virtual Livro Livro { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}

