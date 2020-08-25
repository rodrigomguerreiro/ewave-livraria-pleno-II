using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.EF.Data;



namespace ToDo.Infrastructure.EF.Repositories
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(ToDoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Livro>> ListAll()
        {
          return await ToDoDataContext.Set<Livro>().ToListAsync();
        }
    }
}
