using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.RoomTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.RoomTypes;
using AnytourApi.Dtos.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers;

public class RoomTypeControllerTest : BaseCrudControllerTest<
    GetRoomTypeDto,
    UpdateRoomTypeDto,
    CreateRoomTypeDto,
    IRoomTypeService,
    RoomType,
    GetRoomTypeDto,
    ReturnPageDto<GetRoomTypeDto>,
    RoomTypeController>
{
    public RoomTypeControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        alternativeServices.AddSingleton<IRoomTypeRepository, RoomTypeRepository>();

        alternativeServices.AddSingleton<IRoomTypeService, RoomTypeService>();

        return alternativeServices;
    }

    protected override async Task<RoomTypeController> GetController(IServiceProvider alternativeServices)
    {
        return new RoomTypeController(alternativeServices.GetRequiredService<IRoomTypeService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override CreateRoomTypeDto GetCreateDtoSample()
    {
        return SharedRoomTypeModels.GetSampleCreateDto();
    }


    protected override RoomType GetModelSample()
    {
        return SharedRoomTypeModels.GetSample();
    }

    protected override UpdateRoomTypeDto GetUpdateDtoSample()
    {
        return SharedRoomTypeModels.GetSampleUpdateDto();
    }
}
