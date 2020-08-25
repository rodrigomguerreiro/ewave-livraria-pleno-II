using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.Repositories
{
    public interface IEntity
    {
        int Id { get; set; }
        Guid AggregateId { get; set; }
    }
}
