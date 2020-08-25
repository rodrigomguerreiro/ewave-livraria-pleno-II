using System;
using ToDo.Domain.Repositories;

namespace ToDo.Domain.Entities
{
    public class Livro : IEntity
    {
        public int Id { get; set; }
        public Guid AggregateId { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public string Capa { get; set; }
        public bool Ativo { get; set; }
        public int SituacaoLivroId { get; set; }
        public virtual SituacaoLivro SituacaoLivro { get; set; }
        public int AutorId { get; set; }
        public virtual Autor Autor { get; set; }
        public int GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
    }
}

