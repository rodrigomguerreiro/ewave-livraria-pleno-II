using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Services
{
    public interface IEmprestimoService
    {
        Task CriarAsync(Guid aggregateId, int livroId, int usuarioId);

        Task EncerrarAsync(Guid aggregateId);

        Task<IEnumerable<Emprestimo>> ListAll();
        Task<Emprestimo> ObterPorAsync(int id);
    }
}
