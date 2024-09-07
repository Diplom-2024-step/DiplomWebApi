using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Cities;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Cities;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.Cities;

public class CityServiceTest : SharedServiceTest<
    GetCityDto,
    CreateCityDto,
    UpdateCityDto,
    City,
    GetCityDto,
    ICityRepository,
    ICityService
    >
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(GetDatabaseContext());

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton<ICityRepository, CityRepository>();

        alternativeServices.AddSingleton<ICountryRepository, CountryRepository>();


        return alternativeServices;
    }

    protected override CreateCityDto GetCreateDtoSample()
    {
        return SharedCityModels.GetSampleCreateDto();
    }

    protected override UpdateCityDto GetUpdateDtoSample()
    {
        return SharedCityModels.GetSampleUpdateDto();
    }

    protected override ICityService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new CityService(builder.GetRequiredService<ICityRepository>(), builder.GetRequiredService<ICountryRepository>(), Mapper);

    }
}
