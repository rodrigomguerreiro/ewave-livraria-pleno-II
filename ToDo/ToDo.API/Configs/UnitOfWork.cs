using System;
using System.Threading.Tasks;
using ToDo.Infrastructure.EF.Data;
using ToDo.Infrastructure.EF.UOW;

namespace ToDo.API.Configs
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoContext _context;

        public UnitOfWork(ToDoContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                _context.Dispose();
            }
        }
    }
}
