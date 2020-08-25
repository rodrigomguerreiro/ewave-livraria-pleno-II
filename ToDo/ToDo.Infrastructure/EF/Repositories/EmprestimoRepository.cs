using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.EF.Data;

namespace ToDo.Infrastructure.EF.Repositories
{
    public class EmprestimoRepository : Repository<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoRepository(ToDoContext context) : base(context)
        {
        }

        public async Task<int> GetEmprestimosAtivosPorUsuarioAsync(int usuarioId)
        {
            return await ToDoDataContext.Set<Emprestimo>().CountAsync(x => x.UsuarioId == usuarioId && !x.DataDevolucao.HasValue);
        }

        public async Task<bool> PossuiEmprestimoAtrasadoPorUsuarioAsync(int usuarioId)
        {

            return await ToDoDataContext.Set<Emprestimo>()
                .AnyAsync(x => x.UsuarioId == usuarioId && !x.DataDevolucao.HasValue && x.DataVencimento.Date <= DateTime.Now.Date);
        }

        public async Task<IEnumerable<Emprestimo>> ListAll()
        {
            return await ToDoDataContext.Set<Emprestimo>().ToListAsync();
        }
    }
}
