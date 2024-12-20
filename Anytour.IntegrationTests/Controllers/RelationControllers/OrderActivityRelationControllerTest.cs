﻿using Anytour.IntegrationTests.shared;
using Anytour.IntegrationTests.Shared;
using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Relations.OrderActivities;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers.Orders;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.RelationControllers;

//public class OrderActivityRelationControllerTest : BaseRelationControllerTest<
//    OrderActivity, Order, Activity,
//    OrderActivityRelationController, IOrderActivityRelationService, IOrderActivityRelationRepository
//    >
//{
//    public OrderActivityRelationControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
//    {
//    }

//    protected override Task<Guid> CreateFirstModel(IServiceProvider serviceProvider)
//    {
//        return SharedOrderModels.CreateModelWithAllDependenciesAsync(serviceProvider, CancellationToken);
//    }

//    protected override Task<Guid> CreateSecondModel(IServiceProvider serviceProvider)
//    {
//        return SharedActivityModels.CreateModelWithAllDependenciesAsync(serviceProvider, CancellationToken);
//    }

//    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
//    {
//        alternativeServices.AddSingleton(AppDbContext);
//        alternativeServices.AddSingleton(Mapper);
//        alternativeServices.AddSingleton(UserManager);

//        alternativeServices.AddSingleton(RoleManager);


//        SharedActivityModels.AddAllDependencies(alternativeServices);
//        SharedOrderModels.AddAllDependencies(alternativeServices);

//        alternativeServices.AddScoped<IOrderActivityRelationRepository, OrderActivityRelationRepository>();

//        alternativeServices.AddScoped<IOrderActivityRelationService, OrderActivityRelationService>();

//        return alternativeServices;
//    }

//    protected override async Task<OrderActivityRelationController>  GetRelationController(IServiceProvider serviceProvider, CancellationToken cancellationToken)
//    {
//        return new OrderActivityRelationController(
//            serviceProvider.GetService<IOrderActivityRelationService>(),
//            await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext))
//            );
//    }
//}