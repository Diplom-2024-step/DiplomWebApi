using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.OrderStatuses;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.OrderStatuses;
using AnytourApi.Dtos.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using DiplomWebApi.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace DiplomWebApi.IntegrationTests.Controllers.CrudControllers;

public class OrderStatusControllerTest : BaseCrudControllerTest<
    GetOrderStatusDto,
    UpdateOrderStatusDto,
    CreateOrderStatusDto,
    IOrderStatusService,
    OrderStatus,
    GetOrderStatusDto,
    ReturnPageDto<GetOrderStatusDto>,
    OrderStatusController>
{
    public OrderStatusControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(AppDbContext);
        alternativeServices.AddSingleton(Mapper);
        alternativeServices.AddSingleton(UserManager);
        alternativeServices.AddSingleton(RoleManager);
        alternativeServices.AddSingleton<IOrderStatusRepository, OrderStatusRepository>();
        alternativeServices.AddSingleton<IOrderStatusService, OrderStatusService>();
        return alternativeServices;
    }

    protected override async Task<OrderStatusController> GetController(IServiceProvider alternativeServices)
    {
        return new OrderStatusController(alternativeServices.GetRequiredService<IOrderStatusService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override CreateOrderStatusDto GetCreateDtoSample()
    {
        return SharedOrderStatusModels.GetSampleCreateDto();
    }

    protected override OrderStatus GetModelSample()
    {
        return SharedOrderStatusModels.GetSample();
    }

    protected override UpdateOrderStatusDto GetUpdateDtoSample()
    {
        return SharedOrderStatusModels.GetSampleUpdateDto();
    }
}

