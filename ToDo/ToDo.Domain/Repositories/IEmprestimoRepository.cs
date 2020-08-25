using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories
{
    public interface IEmprestimoRepository : IRepository<Emprestimo>
    {
        Task<IEnumerable<Emprestimo>> ListAll();
        Task<int> GetEmprestimosAtivosPorUsuarioAsync(int usuarioId);
        Task<bool> PossuiEmprestimoAtrasadoPorUsuarioAsync(int usuarioId);
    }
}
