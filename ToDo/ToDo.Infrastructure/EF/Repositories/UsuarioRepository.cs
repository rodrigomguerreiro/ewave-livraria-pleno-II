using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.EF.Data;



namespace ToDo.Infrastructure.EF.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ToDoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Usuario>> ListAll()
        {
          return await ToDoDataContext.Set<Usuario>().ToListAsync();
        }
    }
}
