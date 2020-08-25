using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.EF.Data;

namespace ToDo.Infrastructure.EF.Repositories
{
    public class InstituicaoEnsinoRepository : Repository<InstituicaoEnsino>, IInstituicaoEnsinoRepository
    {
        public InstituicaoEnsinoRepository(ToDoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<InstituicaoEnsino>> ListAll()
        {
            return await ToDoDataContext.Set<InstituicaoEnsino>().ToListAsync();
        }
    }
}
