using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Constants.Shared;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Infrastructure.JwtTokenFactories;
using Microsoft.EntityFrameworkCore;
using Scrutor;

namespace AnytourApi.WebApi.Extensions;

public static class DependencyInjectionExtensions
{

    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(AppSettingsStringConstants.DefaultConnection);
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString, x => x.MigrationsAssembly("EfPersistence")).UseLazyLoadingProxies());



        services.Scan(scan =>
            scan.FromAssembliesOf([
                typeof(ICrudRepository<>),
                typeof(CrudRepository<>),
                typeof(ICrudService<,,,,>),
                typeof(CrudService<,,,,,>)
            ])
            .AddClasses(x => x.AssignableTo(typeof(ICrudRepository<>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithScopedLifetime()
            .AddClasses(x => x.AssignableTo(typeof(ICrudService<,,,,>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithScopedLifetime()
            );


        services.AddScoped<IJwtTokenFactory, JwtTokenFactory>();





    }
}
