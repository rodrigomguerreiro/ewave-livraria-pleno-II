using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.EF.Data;



namespace ToDo.Infrastructure.EF.Repositories
{
    public class SituacaoLivroRepository : Repository<SituacaoLivro>, ISituacaoLivroRepository
    {
        public SituacaoLivroRepository(ToDoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SituacaoLivro>> ListAll()
        {
          return await ToDoDataContext.Set<SituacaoLivro>().ToListAsync();
        }
    }
}
