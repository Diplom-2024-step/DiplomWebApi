﻿using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Constants.Shared;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Infrastructure.JwtTokenFactories;
using Microsoft.EntityFrameworkCore;
using Scrutor;
using AnytourApi.Application.Repositories.Shared.Relation;
using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Infrastructure.FileHelper;
using AnytourApi.Infrastructure.LinkFactories;
using Npgsql;

namespace AnytourApi.WebApi.Extensions;

public static class DependencyInjectionExtensions
{

    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(AppSettingsStringConstants.DefaultConnection);

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);

        var dataSource = dataSourceBuilder.Build();
        services.AddDbContext<AppDbContext>(options =>
        {
            options
                .UseNpgsql(dataSource)
                .UseLazyLoadingProxies();
        });




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

        services.Scan(scan =>
            scan.FromAssembliesOf([
                typeof(IRelationRepository<,,>),
                typeof(RelationRepository<,,>),
                typeof(IRelationService<,,>),
                typeof(RelationService<,,,>)
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

        services.AddScoped<IFileHelper, FileHelper>();

        services.AddScoped<ILinkFactory, LinkFactory>();





    }
}
