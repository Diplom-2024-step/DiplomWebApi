using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Countries;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Countries;
using AnytourApi.Dtos.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers;


public class CountryControllerTest : BaseCrudControllerTest
    <
    GetCountryDto,
    UpdateCountryDto,
    CreateCountryDto,
    ICountryService,
    Country,
    GetCountryDto,
    ReturnPageDto<GetCountryDto>,
    CountryController
    >
{
    public CountryControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        alternativeServices.AddSingleton<ICountryRepository, CountryRepository>();

        alternativeServices.AddSingleton<ICountryService, CountryService>();

        return alternativeServices;
    }

    protected override async Task<CountryController> GetController(IServiceProvider alternativeServices)
    {
        return new CountryController(alternativeServices.GetRequiredService<ICountryService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override CreateCountryDto GetCreateDtoSample()
    {
        return SharedCountryModels.GetSampleCreateDto();
    }


    protected override Country GetModelSample()
    {
        return SharedCountryModels.GetSample();
    }

    protected override UpdateCountryDto GetUpdateDtoSample()
    {
        return SharedCountryModels.GetSampleUpdateDto();
    }
}
