using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories
{
    public interface IGeneroRepository : IRepository<Genero>
    {
        Task<IEnumerable<Genero>> ListAll();
    }
}
