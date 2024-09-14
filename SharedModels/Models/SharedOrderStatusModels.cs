using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.OrderStatuses;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.OrderStatuses;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models;

public class SharedOrderStatusModels : SharedModelsBase, IShareModels<CreateOrderStatusDto, UpdateOrderStatusDto, OrderStatus>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
        services.AddScoped<IOrderStatusService, OrderStatusService>();
    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var orderStatus = GetSampleCreateDto();
        return await serviceProvider.GetService<IOrderStatusService>().CreateAsync(orderStatus, cancellationToken);
    }

    public static OrderStatus GetSample()
    {
        return new OrderStatus
        {
            Name = "OrderStatusName"
        };
    }

    public static CreateOrderStatusDto GetSampleCreateDto()
    {
        return new CreateOrderStatusDto
        {
            Name = "test"
        };
    }

    public static OrderStatus GetSampleForUpdate()
    {
        return new OrderStatus
        {
            Name = "Name123"
        };
    }

    public static UpdateOrderStatusDto GetSampleUpdateDto()
    {
        return new UpdateOrderStatusDto
        {
            Name = "test12"
        };
    }
}
