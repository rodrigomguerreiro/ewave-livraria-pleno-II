using System;
using ToDo.Domain.Repositories;

namespace ToDo.Domain.Entities
{
    public class Autor : IEntity
    {
        public int Id { get; set; }
        public Guid AggregateId { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}

