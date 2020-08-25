using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.EF.Data;



namespace ToDo.Infrastructure.EF.Repositories
{
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        public AutorRepository(ToDoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Autor>> ListAll()
        {
          return await ToDoDataContext.Set<Autor>().ToListAsync();
        }
    }
}
