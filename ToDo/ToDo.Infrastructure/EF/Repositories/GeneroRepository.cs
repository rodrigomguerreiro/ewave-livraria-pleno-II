using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.EF.Data;



namespace ToDo.Infrastructure.EF.Repositories
{
    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        public GeneroRepository(ToDoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Genero>> ListAll()
        {
          return await ToDoDataContext.Set<Genero>().ToListAsync();
        }
    }
}
