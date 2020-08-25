using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories
{
    public interface IInstituicaoEnsinoRepository : IRepository<InstituicaoEnsino>
    {
       Task <IEnumerable<InstituicaoEnsino>> ListAll();
        
    }
}
