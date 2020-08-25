using System.Threading.Tasks;

namespace ToDo.Infrastructure.EF.UOW
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
