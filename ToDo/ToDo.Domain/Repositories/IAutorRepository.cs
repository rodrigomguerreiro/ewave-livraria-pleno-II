using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories
{
    public interface IAutorRepository : IRepository<Autor>
    {
        Task<IEnumerable<Autor>> ListAll();
    }
}
