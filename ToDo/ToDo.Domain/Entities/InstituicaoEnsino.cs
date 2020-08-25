using System;
using ToDo.Domain.Repositories;

namespace ToDo.Domain.Entities
{
    public class InstituicaoEnsino : IEntity
    {
        public int Id { get; set; }
        public Guid AggregateId { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public bool Ativo { get; set; }
    }
}

