using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
       Task <IEnumerable<Usuario>> ListAll();
    }
}
