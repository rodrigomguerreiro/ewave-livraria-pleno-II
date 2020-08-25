using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using ToDo.Infrastructure.EF.Repositories;

namespace ToDo.Application.Modules
{
    public static class ToDoRepositoriesModule
    {
        public static void UseToDoRepositoriesModule(this IServiceCollection services)
        {
            var repositories = Assembly.GetAssembly(typeof(UsuarioRepository))
                .GetTypes()
                .Where(x => x.Name.EndsWith("Repository"))
                .ToDictionary(x => x.GetInterfaces()[1], x => x);

            foreach (var item in repositories)
            {
                services.AddTransient(item.Key, item.Value);
            }            
        }
    }
}
