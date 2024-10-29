using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Services.Models.Orders;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Orders;
using AnytourApi.Dtos.Shared;
using AnytourApi.Infrastructure.LinkFactories;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers.Orders;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers;

public class OrderControllerTest : BaseCrudControllerTest<
    GetOrderDto,
    UpdateOrderDto,
    CreateOrderDto,
    IOrderService,
    Order,
    GetOrderDto,
    ReturnPageDto<GetOrderDto>,
    OrderController>
{
    public OrderControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }


    protected override async Task MutationBeforeDtoCreation(CreateOrderDto createDto,
      IServiceProvider alternativeServices)
    {
        createDto.HotelId = await SharedHotelModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        createDto.UserId = null;
        createDto.AdminId = null;
        createDto.OrderStatusId = await SharedOrderStatusModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);

        createDto.DietTypeId = await SharedDietTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        createDto.TransportationTypeId = await SharedTransportationTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        createDto.FromCityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        createDto.ToCityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);

        createDto.RoomTypeId = await SharedRoomTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);

    }

    protected override async Task MutationBeforeDtoUpdate(UpdateOrderDto updateDto,
         IServiceProvider alternativeServices)
    {
        updateDto.HotelId = await SharedTourModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        updateDto.UserId = null;
        updateDto.AdminId = null;
        updateDto.OrderStatusId = await SharedOrderStatusModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        updateDto.DietTypeId = await SharedDietTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        updateDto.TransportationTypeId = await SharedTransportationTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        updateDto.FromCityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        updateDto.ToCityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);

        updateDto.RoomTypeId = await SharedRoomTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        SharedOrderModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }

    protected override async Task<OrderController> GetController(IServiceProvider alternativeServices)
    {
        return new OrderController(alternativeServices.GetRequiredService<IOrderService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override CreateOrderDto GetCreateDtoSample()
    {
        return SharedOrderModels.GetSampleCreateDto();
    }


    protected override Order GetModelSample()
    {
        return SharedOrderModels.GetSample();
    }

    protected override UpdateOrderDto GetUpdateDtoSample()
    {
        return SharedOrderModels.GetSampleUpdateDto();
    }
}
