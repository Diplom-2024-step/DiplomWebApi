using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Cities;
using AnytourApi.Application.Services.Models.Countries;
using AnytourApi.Application.Services.Models.Hotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Hotels;
using AnytourApi.Dtos.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers;

public class HotelControllerTest: BaseCrudControllerTest
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


    protected override async  Task MutationBeforeDtoCreation(CreateHotelDto createDto,
      IServiceProvider alternativeServices)
    {

          var countryId = await alternativeServices.GetRequiredService<ICountryService>().CreateAsync(SharedCountryModels.GetSampleCreateDto(), CancellationToken);

        var city = SharedCityModels.GetSampleCreateDto();

        city.CountryId = countryId;

        var cityId = await alternativeServices.GetRequiredService<ICityService>().CreateAsync(city, CancellationToken);
        createDto.CityId = cityId;


    }

    protected override async Task MutationBeforeDtoUpdate(UpdateHotelDto updateDto,
         IServiceProvider alternativeServices)
    {

        var countryId = await alternativeServices.GetRequiredService<ICountryService>().CreateAsync(SharedCountryModels.GetSampleCreateDto(), CancellationToken);

        var city = SharedCityModels.GetSampleCreateDto();

        city.CountryId = countryId;

        var cityId = await alternativeServices.GetRequiredService<ICityService>().CreateAsync(city, CancellationToken);
        updateDto.CityId = cityId;
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        alternativeServices.AddSingleton<ICountryRepository, CountryRepository>();

        alternativeServices.AddSingleton<ICountryService, CountryService>();

        alternativeServices.AddSingleton<ICityRepository, CityRepository>();

        alternativeServices.AddSingleton<ICityService, CityService>();



        alternativeServices.AddSingleton<IHotelRepository, HotelRepository>();

        alternativeServices.AddSingleton<IHotelService, HotelService>();

        return alternativeServices;
    }

    protected override async Task<HotelController> GetController(IServiceProvider alternativeServices)
    {
        return new HotelController(alternativeServices.GetRequiredService<IHotelService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
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