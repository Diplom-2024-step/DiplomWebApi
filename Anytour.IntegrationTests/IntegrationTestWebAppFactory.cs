using AnytourApi.EfPersistence.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;
using Xunit;

namespace Anytour.IntegrationTests;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainder = new PostgreSqlBuilder()
        .WithImage("postgres:latest")
        .WithDatabase("diplom")
        .WithUsername("postgres")
        .WithPassword("root")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder) 
    {
        builder.ConfigureTestServices(
            services => {
                var descriptor = services
                    .SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<AppDbContext>));

                if (descriptor is not null) 
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<AppDbContext>(options => 
                {
                    options
                        .UseNpgsql(_dbContainder.GetConnectionString())
                        .UseLazyLoadingProxies();
                
                }
                    );

            });
    }

    public Task InitializeAsync()
    {
        return _dbContainder.StartAsync();
    }


    public new  Task DisposeAsync()
    {
        return _dbContainder.StopAsync();
    }
}
