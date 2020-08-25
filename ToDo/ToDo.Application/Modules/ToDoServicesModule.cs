using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using ToDo.Application.Services;

namespace ToDo.Application.Modules
{
    public static class ToDoServicesModule
    {
        public static void UseToDoServicesModule(this IServiceCollection services)
        {
            var appServices = Assembly.GetAssembly(typeof(UsuarioService))
                .GetTypes()
                .Where(x => x.Name.EndsWith("Service"))
                .ToDictionary(x => x.GetInterfaces()[0], x => x);

            foreach (var item in appServices)
            {
                services.AddTransient(item.Key, item.Value);
            }
        }
    }
}
