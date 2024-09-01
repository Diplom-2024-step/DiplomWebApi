using Application.Repositories;
using EfPersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.ServiceDefaults
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AnytourDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();

            return services;
        }
    }
}
