using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Services
{
    public interface IAutorService
    {
        Task CriarAsync(Guid aggregateId, string nome);

        Task AtualizarAsync(Guid aggregateId, string nome, bool ativo);

        Task<IEnumerable<Autor>> ListAll();
        Task<Autor> ObterPorAsync(int id);
    }
}
