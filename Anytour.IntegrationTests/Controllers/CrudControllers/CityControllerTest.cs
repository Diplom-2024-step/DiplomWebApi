using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Cities;
using AnytourApi.Application.Services.Models.Countries;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Cities;
using AnytourApi.Dtos.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers;

public class CityControllerTest: BaseCrudControllerTest
    <
    GetCityDto,
    UpdateCityDto,
    CreateCityDto,
    ICityService,
    City,
    GetCityDto,
    ReturnPageDto<GetCityDto>,
    CityController
    >
{



    public CityControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }


    protected override async  Task MutationBeforeDtoCreation(CreateCityDto createDto,
      IServiceProvider alternativeServices)
    {

        var countryId = await alternativeServices.GetRequiredService<ICountryService>().CreateAsync(SharedCountryModels.GetSampleCreateDto(), CancellationToken);
        createDto.CountryId = countryId;


    }

    protected override async Task MutationBeforeDtoUpdate(UpdateCityDto updateDto,
         IServiceProvider alternativeServices)
    {

        var countryId = await alternativeServices.GetRequiredService<ICountryService>().CreateAsync(SharedCountryModels.GetSampleCreateDto(), CancellationToken);
        updateDto.CountryId = countryId;
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        SharedCityModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }

    protected override async Task<CityController> GetController(IServiceProvider alternativeServices)
    {
        return new CityController(alternativeServices.GetRequiredService<ICityService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override CreateCityDto GetCreateDtoSample()
    {
        return SharedCityModels.GetSampleCreateDto();
    }


    protected override City GetModelSample()
    {
        return SharedCityModels.GetSample();
    }

    protected override UpdateCityDto GetUpdateDtoSample()
    {
        return SharedCityModels.GetSampleUpdateDto();
    }
}
