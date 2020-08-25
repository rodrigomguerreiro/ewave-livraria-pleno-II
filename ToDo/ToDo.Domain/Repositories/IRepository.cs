using System;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> GetByAsync(int id);
        Task<T> GetByAggregateIdAsync(Guid aggregateId);
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
    }

}
