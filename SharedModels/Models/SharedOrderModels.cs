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
        SharedHotelModels.AddAllDependencies(services);
        SharedActivityModels.AddAllDependencies(services);

        
    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var orderDto = SharedOrderModels.GetSampleCreateDto();

        orderDto.HotelId = await SharedHotelModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        orderDto.UserId = await SharedUserModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        orderDto.AdminId = await SharedUserModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        orderDto.OrderStatusId = await SharedOrderStatusModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        orderDto.DietTypeId = await SharedDietTypeModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        orderDto.TransportationTypeId = await SharedTransportationTypeModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        orderDto.FromCityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        orderDto.ToCityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        orderDto.ActivityIds = [await SharedActivityModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken)];
        

        return await serviceProvider.GetService<IOrderService>().CreateAsync(orderDto, cancellationToken);
    }

    public static Order GetSample()
    {
        return new Order()
        {
            Hotel = SharedHotelModels.GetSample(),
            PriceUSD = 1000,
            StartDate = DateTime.Now.ToUniversalTime(),
            EndDate = DateTime.Now.AddDays(15).ToUniversalTime(),
            MobilePhoneNumber = "+380775493296",
            FullName = "FullName",
            User = null,
            Admin = null,
            OrderStatus = SharedOrderStatusModels.GetSample(),
            DietType = SharedDietTypeModels.GetSample(),
            Duration = 10,
            FromCity = SharedCityModels.GetSample(),
            HowManyAdults = 1,
            HowManyKids = 1,
            RoomType = SharedRoomTypeModels.GetSample(),
            ToCity = SharedCityModels.GetSample(),
            TransportationType = SharedTransportationTypeModels.GetSample(),
            Activities = [SharedActivityModels.GetSample()]

        };
        
    }

    public static CreateOrderDto GetSampleCreateDto()
    {
        return new CreateOrderDto()
        {
            HotelId = Guid.NewGuid(),
            PriceUSD = 1000,
            StartDate = DateTime.Now.ToUniversalTime(),
            EndDate = DateTime.Now.AddDays(15).ToUniversalTime(),
            MobilePhoneNumber = "+380775493296",
            FullName = "FullName",
            UserId = null,
            AdminId = null,
            OrderStatusId = Guid.NewGuid(),
            DietTypeId = Guid.NewGuid(),
            Duration = 10,
            FromCityId = Guid.NewGuid(),
            HowManyAdults = 10,
            HowManyKids=10,
            RoomTypeId = Guid.NewGuid(),
            ToCityId = Guid.NewGuid(),
            TransportationTypeId = Guid.NewGuid(),
            ActivityIds = [Guid.NewGuid()]
        };
    }

    public static Order GetSampleForUpdate()
    {
        return new Order()
        {
            Hotel = SharedHotelModels.GetSampleForUpdate(),
            PriceUSD = 1500,
            StartDate = DateTime.Now.ToUniversalTime(),
            EndDate = DateTime.Now.AddDays(15).ToUniversalTime(),
            MobilePhoneNumber = "+380996443293",
            FullName = Lorem.GetFirstWord() + "12",
            User = null,          
            Admin = null,
            OrderStatus = SharedOrderStatusModels.GetSampleForUpdate(),
            DietType = SharedDietTypeModels.GetSampleForUpdate(),
            Duration = 11,
            FromCity = SharedCityModels.GetSampleForUpdate(),
            HowManyAdults = 11,
            HowManyKids = 11,
            RoomType = SharedRoomTypeModels.GetSampleForUpdate(),
            ToCity = SharedCityModels.GetSampleForUpdate(),
            TransportationType = SharedTransportationTypeModels.GetSample(),
            Activities = [SharedActivityModels.GetSample()]
        };
    }

    public static UpdateOrderDto GetSampleUpdateDto()
    {
        return new UpdateOrderDto()
        {
            HotelId = Guid.NewGuid(),
            PriceUSD = 1000,
            StartDate = DateTime.Now.ToUniversalTime(),
            EndDate = DateTime.Now.AddDays(12).ToUniversalTime(),
            MobilePhoneNumber = "+380581236296",
            FullName = "FullName12",
            UserId = null,
            AdminId = null,
            OrderStatusId = Guid.NewGuid(),
            DietTypeId = Guid.NewGuid(),
            Duration = 2,
            FromCityId = Guid.NewGuid(),
            HowManyAdults = 1,
            HowManyKids = 1,
            RoomTypeId = Guid.NewGuid(),
            ToCityId = Guid.NewGuid(),
            TransportationTypeId = Guid.NewGuid(),
            ActivityIds = [Guid.NewGuid()]
        };
    }
}
