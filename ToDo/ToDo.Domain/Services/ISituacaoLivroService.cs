using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Services
{
    public interface ISituacaoLivroService
    {
        Task CriarAsync(Guid aggregateId, string descricao, bool ativo);

        Task AtualizarAsync(Guid aggregateId, string descricao, bool ativo);

        Task<IEnumerable<SituacaoLivro>> ListAll();
        Task<SituacaoLivro> ObterPorAsync(int id);
    }
}
