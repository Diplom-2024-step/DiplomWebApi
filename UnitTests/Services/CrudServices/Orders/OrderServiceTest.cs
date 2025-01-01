//using AnytourApi.Application.Repositories.Models;
//using AnytourApi.Application.Repositories.Users;
//using AnytourApi.Application.Services.Models.Orders;
//using AnytourApi.Domain.Models.Enteties;
//using AnytourApi.Dtos.Dto.Models.Orders;
//using AnytourApi.EfPersistence.Repositories.Models;
//using AnytourApi.EfPersistence.Repositories;
//using AnytourApi.SharedModels.Models;
//using AnytourApi.UnitTests.Shared.Services;
//using Microsoft.Extensions.DependencyInjection;
//using AnytourApi.Application.Repositories.Polimorfizms.Photoables;
//using AnytourApi.Application.Services.Models.Photos;

//namespace AnytourApi.UnitTests.Services.CrudServices.Orders;

//public class OrderServiceTest : SharedServiceTest<
//    GetOrderDto,
//    CreateOrderDto,
//    UpdateOrderDto,
//    Order,
//    GetOrderDto,
//    IOrderRepository,
//    IOrderService>
//{
//    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
//    {
//        var dbContext = GetDatabaseContext();
//        alternativeServices.AddSingleton(dbContext);

//        alternativeServices.AddSingleton(GetUserManager(dbContext));

//        alternativeServices.AddSingleton(Mapper);

//        alternativeServices.AddSingleton<IOrderRepository, OrderRepository>();

//        alternativeServices.AddSingleton<ITourRepository, TourRepository>();

//        alternativeServices.AddSingleton<IUserRepository, UserRepository>();
        
//        alternativeServices.AddSingleton<IOrderStatusRepository, OrderStatusRepository>();

//        SharedOrderModels.AddAllDependencies(alternativeServices);

//        return alternativeServices;
//    }

//    protected override CreateOrderDto GetCreateDtoSample()
//    {
//        return SharedOrderModels.GetSampleCreateDto();
//    }

//    protected override UpdateOrderDto GetUpdateDtoSample()
//    {
//        return SharedOrderModels.GetSampleUpdateDto();
//    }

//    protected override IOrderService GetService(IServiceCollection alternativeServices)
//    {
//        var builder = alternativeServices.BuildServiceProvider();

//        return new OrderService(builder.GetRequiredService<IOrderRepository>(),
//            builder.GetRequiredService<IHotelRepository>(),
//            builder.GetRequiredService<IUserRepository>(),
//            builder.GetRequiredService<IOrderStatusRepository>(),
//            builder.GetRequiredService<ITransportationTypeRepository>(),
//            builder.GetRequiredService<ICityRepository>(),
//            builder.GetRequiredService<IDietTypeRepository>(),
//            builder.GetRequiredService<IRoomTypeRepository>(),
//            builder.GetRequiredService<IActivityRepository>(),
//            builder.GetRequiredService<IPhotoService>(),
//            Mapper);

//    }
//}
