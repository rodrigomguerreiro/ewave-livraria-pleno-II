using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Services
{
    public interface ILivroService
    {
        Task CriarAsync(Guid aggregateId, string titulo, string sinopse, string capa, int autorId, int generoId, int situacaoLivroId, bool ativo);

        Task AtualizarAsync(Guid aggregateId, string titulo, string sinopse, string capa, int autorId, int generoId, int situacaoLivroId, bool ativo);

        Task<IEnumerable<Livro>> ListAll();
        Task<Livro> ObterPorAsync(int id);
    }
}
