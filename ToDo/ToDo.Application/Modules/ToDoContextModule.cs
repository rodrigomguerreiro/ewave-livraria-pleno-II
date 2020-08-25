using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Infrastructure.EF.Data;

namespace ToDo.Application.Modules
{
    public static class ToDoContextModule
    {
        public static void UseToDoContextModule(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ToDo");

            services.AddDbContext<ToDoContext>(options =>
            {
                options
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies();
            });

            services.AddScoped<ToDoContext>();
        }
    }
}
