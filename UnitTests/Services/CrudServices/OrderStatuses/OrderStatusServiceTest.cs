using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.OrderStatuses;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.OrderStatuses;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.OrderStatuses;

public class OrderStatusServiceTest : SharedServiceTest<
    GetOrderStatusDto,
    CreateOrderStatusDto,
    UpdateOrderStatusDto,
    OrderStatus,
    GetOrderStatusDto,
    IOrderStatusRepository,
    IOrderStatusService>
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(GetDatabaseContext());
        alternativeServices.AddSingleton(Mapper);
        alternativeServices.AddSingleton<IOrderStatusRepository, OrderStatusRepository>();
        return alternativeServices;
    }

    protected override CreateOrderStatusDto GetCreateDtoSample()
    {
        return SharedOrderStatusModels.GetSampleCreateDto();
    }

    protected override UpdateOrderStatusDto GetUpdateDtoSample()
    {
        return SharedOrderStatusModels.GetSampleUpdateDto();
    }

    protected override IOrderStatusService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();
        return new OrderStatusService(builder.GetRequiredService<IOrderStatusRepository>(), Mapper);
    }
}

