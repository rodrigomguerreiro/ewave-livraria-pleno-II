using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories
{
    public interface ISituacaoLivroRepository : IRepository<SituacaoLivro>
    {
        Task<IEnumerable<SituacaoLivro>> ListAll();
    }
}
