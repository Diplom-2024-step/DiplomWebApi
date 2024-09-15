using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Cities;
using AnytourApi.Application.Services.Models.Countries;
using AnytourApi.Application.Services.Models.Hotels;
using AnytourApi.Application.Services.Models.InHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Hotels;
using AnytourApi.Dtos.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.Infrastructure.LinkFactories;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers.Hotels;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers;

public class HotelControllerTest : BaseCrudControllerTest
    <
    GetHotelDto,
    UpdateHotelDto,
    CreateHotelDto,
    IHotelService,
    Hotel,
    GetHotelDto,
    ReturnPageDto<GetHotelDto>,
    HotelController
    >
{



    public HotelControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }


    protected override async Task MutationBeforeDtoCreation(CreateHotelDto createDto,
      IServiceProvider alternativeServices)
    {

        createDto.CityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);

        var inHotelId = await SharedInHotelModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);

        var forSportId = await SharedForSportModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);

        var beachTypeId = await SharedBeachTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);

        var roomTypeId = await SharedRoomTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);

        createDto.InHotelIds = [inHotelId];
        createDto.ForSportIds = [forSportId];
        createDto.BeachTypeIds = [beachTypeId];
        createDto.RoomTypeIds = [roomTypeId];


    }

    protected override async Task MutationBeforeDtoUpdate(UpdateHotelDto updateDto,
         IServiceProvider alternativeServices)
    {

        updateDto.CityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);

        var inHotelId = await SharedInHotelModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        var forSportId = await SharedForSportModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        var beachTypeId = await SharedBeachTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        var roomTypeId = await SharedRoomTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);

        updateDto.InHotelIds = [inHotelId];
        updateDto.ForSportIds = [forSportId];
        updateDto.BeachTypesIds = [beachTypeId];
        updateDto.RoomTypeIds = [roomTypeId];

    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        SharedHotelModels.AddAllDependencies(alternativeServices);
        
        return alternativeServices;
    }

    protected override async Task<HotelController> GetController(IServiceProvider alternativeServices)
    {
        return new HotelController(alternativeServices.GetRequiredService<IHotelService>(), alternativeServices.GetRequiredService<ILinkFactory>(),await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override CreateHotelDto GetCreateDtoSample()
    {
        return SharedHotelModels.GetSampleCreateDto();
    }


    protected override Hotel GetModelSample()
    {
        return SharedHotelModels.GetSample();
    }

    protected override UpdateHotelDto GetUpdateDtoSample()
    {
        return SharedHotelModels.GetSampleUpdateDto();
    }
}