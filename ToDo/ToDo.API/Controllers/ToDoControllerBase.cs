using Microsoft.AspNetCore.Mvc;
using ToDo.API.Configs;
using ToDo.Infrastructure.EF.UOW;

namespace ToDo.API.Controllers
{
    [AppExceptionFilter]
    public abstract class ToDoControllerBase : ControllerBase
    {

        protected readonly IUnitOfWork UnitOfWork;

        public ToDoControllerBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
