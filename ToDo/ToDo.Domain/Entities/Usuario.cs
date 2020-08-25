using System;
using System.Collections;
using System.Collections.Generic;
using ToDo.Domain.Repositories;

namespace ToDo.Domain.Entities
{
    public class Usuario : IEntity
    {
        public int Id { get; set; }
        public Guid AggregateId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int InstituicaoEnsinoId { get; set; }
        public virtual InstituicaoEnsino InstituicaoEnsino { get; set; }
        public int? EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Emprestimo> Emprestimos { get; set; } = new HashSet<Emprestimo>();
        public bool Ativo { get; set; }
    }
}

