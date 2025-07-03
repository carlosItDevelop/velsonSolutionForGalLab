
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure<TContext>(
            this IServiceCollection services, 
            string connectionString) 
            where TContext : DbContext
        {
            // Configurar DbContext
            services.AddDbContext<TContext>(options =>
                options.UseSqlServer(connectionString));

            // Registrar repositórios
            services.AddScoped<DbContext>(provider => provider.GetService<TContext>());
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
