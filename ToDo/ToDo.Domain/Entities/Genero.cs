using System;
using ToDo.Domain.Repositories;

namespace ToDo.Domain.Entities
{
    public class Genero : IEntity
    {
        public int Id { get; set; }
        public Guid AggregateId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}

