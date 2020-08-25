using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.Extensions;

namespace ToDo.Infrastructure.EF.Data
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
        {
        protected ToDoContext ToDoDataContext { get; }

        protected Repository(ToDoContext context)
        {
            ToDoDataContext = context;
        }

        public async Task CreateAsync(T entity)
        {
            await ToDoDataContext.Set<T>().AddAsync(entity);
        }

        public Task RemoveAsync(T entity)
        {
            ToDoDataContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T> GetByAsync(int id)
        {
            var result = ToDoDataContext.Set<T>().Local.SingleOrDefault(obj => obj.Id == id);

            if (result.IsNull())
            {
                result = await ToDoDataContext.Set<T>().SingleOrDefaultAsync(obj => obj.Id == id);
            }

            return result;
        }

        public Task UpdateAsync(T entity)
        {
            ToDoDataContext.Entry<T>(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task<T> GetByAggregateIdAsync(Guid aggregateId)
        {
            var result = ToDoDataContext.Set<T>().Local.SingleOrDefault(obj => obj.AggregateId == aggregateId);

            if (result.IsNull())
            {
                result = await ToDoDataContext.Set<T>().SingleOrDefaultAsync(obj => obj.AggregateId == aggregateId);
            }

            return result;
        }
    }
}
