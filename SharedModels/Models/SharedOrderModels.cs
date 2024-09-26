using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Orders;
using AnytourApi.Application.Services.Models.Tours;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Orders;
using AnytourApi.Dtos.Dto.Models.Tours;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Shared;
using Faker;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models;

public class SharedOrderModels : SharedModelsBase, IShareModels<CreateOrderDto, UpdateOrderDto, Order>
{
    public static void AddAllDependencies(IServiceCollection services)
    {

        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddScoped<IOrderService, OrderService>();

        SharedReviewablePhotoableModels.AddAllDependencies(services);
        SharedUserModels.AddAllDependencies(services);
        SharedOrderStatusModels.AddAllDependencies(services);
        SharedTourModels.AddAllDependencies(services);

        
    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var orderDto = SharedOrderModels.GetSampleCreateDto();

        orderDto.TourId = await SharedTourModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        orderDto.UserId = await SharedUserModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        orderDto.AdminId = await SharedUserModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        orderDto.OrderStatusId = await SharedOrderStatusModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);

        return await serviceProvider.GetService<IOrderService>().CreateAsync(orderDto, cancellationToken);
    }

    public static Order GetSample()
    {
        return new Order()
        {
            Tour = SharedTourModels.GetSample(),
            PriceUSD = 1000,
            StartDate = DateTime.Now.ToUniversalTime(),
            EndDate = DateTime.Now.AddDays(15).ToUniversalTime(),
            MobilePhoneNumber = "+380775493296",
            FullName = "FullName",          
            User = null,
            Admin = null,
            OrderStatus = SharedOrderStatusModels.GetSample(),
        };
    }

    public static CreateOrderDto GetSampleCreateDto()
    {
        return new CreateOrderDto()
        {
            TourId = Guid.NewGuid(),
            PriceUSD = 1000,
            StartDate = DateTime.Now.ToUniversalTime(),
            EndDate = DateTime.Now.AddDays(15).ToUniversalTime(),
            MobilePhoneNumber = "+380775493296",
            FullName = "FullName",
            UserId = null,
            AdminId = null,
            OrderStatusId = Guid.NewGuid(),
        };
    }

    public static Order GetSampleForUpdate()
    {
        return new Order()
        {
            Tour = SharedTourModels.GetSampleForUpdate(),
            PriceUSD = 1500,
            StartDate = DateTime.Now.ToUniversalTime(),
            EndDate = DateTime.Now.AddDays(15).ToUniversalTime(),
            MobilePhoneNumber = "+380996443293",
            FullName = Lorem.GetFirstWord() + "12",
            User = null,          
            Admin = null,
            OrderStatus = SharedOrderStatusModels.GetSampleForUpdate(),
        };
    }

    public static UpdateOrderDto GetSampleUpdateDto()
    {
        return new UpdateOrderDto()
        {
            TourId = Guid.NewGuid(),
            PriceUSD = 1000,
            StartDate = DateTime.Now.ToUniversalTime(),
            EndDate = DateTime.Now.AddDays(12).ToUniversalTime(),
            MobilePhoneNumber = "+380581236296",
            FullName = "FullName12",
            UserId = null,
            AdminId = null,
            OrderStatusId = Guid.NewGuid(),
        };
    }
}
