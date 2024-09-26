using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Orders;
using AnytourApi.Application.Services.Models.ProcessedOrders;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Orders;
using AnytourApi.Dtos.Dto.Models.ProcessedOrders;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Shared;
using Faker;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnytourApi.SharedModels.Models;

public class SharedProcessedOrderModels : SharedModelsBase, IShareModels<CreateProcessedOrderDto, UpdateProcessedOrderDto, ProcessedOrder>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        SharedUserModels.AddAllDependencies(services);
        SharedOrderModels.AddAllDependencies(services);
        SharedOrderStatusModels.AddAllDependencies(services);

        services.AddScoped<IProcessedOrderRepository, ProcessedOrderRepository>();

        services.AddScoped<IProcessedOrderService, ProcessedOrderService>();
    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var processedOrderDto = SharedProcessedOrderModels.GetSampleCreateDto();

        processedOrderDto.OrderId = await SharedOrderModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        processedOrderDto.UserId = await SharedUserModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        processedOrderDto.StatusId = await SharedOrderStatusModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);

        return await serviceProvider.GetService<IProcessedOrderService>().CreateAsync(processedOrderDto, cancellationToken);
    }

    public static ProcessedOrder GetSample()
    {
        return new ProcessedOrder()
        {
            Order = SharedOrderModels.GetSample(),
            User = SharedUserModels.GetSample(),
            Status = SharedOrderStatusModels.GetSample(),
        };
    }

    public static CreateProcessedOrderDto GetSampleCreateDto()
    {
        return new CreateProcessedOrderDto()
        {
            OrderId = Guid.NewGuid(),
            UserId = Guid.NewGuid(),
            StatusId = Guid.NewGuid(),
        };
    }

    public static ProcessedOrder GetSampleForUpdate()
    {
        return new ProcessedOrder()
        {
            Order = SharedOrderModels.GetSampleForUpdate(),
            User = SharedUserModels.GetSampleForUpdate(),
            Status = SharedOrderStatusModels.GetSampleForUpdate(),
        };
    }

    public static UpdateProcessedOrderDto GetSampleUpdateDto()
    {
        return new UpdateProcessedOrderDto()
        {
            OrderId = Guid.NewGuid(),
            UserId = Guid.NewGuid(),
            StatusId = Guid.NewGuid(),
        };
    }
}
