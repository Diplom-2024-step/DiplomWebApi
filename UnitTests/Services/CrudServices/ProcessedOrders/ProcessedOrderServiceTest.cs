using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Users;
using AnytourApi.Application.Services.Models.ProcessedOrders;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ProcessedOrders;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.ProcessedOrders;

public class ProcessedOrderServiceTest : SharedServiceTest<
    GetProcessedOrderDto,
    CreateProcessedOrderDto,
    UpdateProcessedOrderDto,
    ProcessedOrder,
    GetProcessedOrderDto,
    IProcessedOrderRepository,
    IProcessedOrderService>
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        var dbContext = GetDatabaseContext();
        alternativeServices.AddSingleton(dbContext);

        alternativeServices.AddSingleton(GetUserManager(dbContext));

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton<IProcessedOrderRepository, ProcessedOrderRepository>();

        alternativeServices.AddSingleton<IOrderRepository, OrderRepository>();

        alternativeServices.AddSingleton<IUserRepository, UserRepository>();

        alternativeServices.AddSingleton<IOrderStatusRepository, OrderStatusRepository>();

        return alternativeServices;
    }

    protected override CreateProcessedOrderDto GetCreateDtoSample()
    {
        return SharedProcessedOrderModels.GetSampleCreateDto();
    }

    protected override UpdateProcessedOrderDto GetUpdateDtoSample()
    {
        return SharedProcessedOrderModels.GetSampleUpdateDto();
    }

    protected override IProcessedOrderService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new ProcessedOrderService(builder.GetRequiredService<IProcessedOrderRepository>(),
            builder.GetRequiredService<IOrderRepository>(),
            builder.GetRequiredService<IUserRepository>(),
            builder.GetRequiredService<IOrderStatusRepository>(),
            Mapper);

    }
}
