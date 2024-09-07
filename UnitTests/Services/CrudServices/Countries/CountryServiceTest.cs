using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Countries;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Countries;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.Countries;

public class CountryServiceTest : SharedServiceTest<
    GetCountryDto,
    CreateCountryDto,
    UpdateCountryDto,
    Country,
    GetCountryDto,
    ICountryRepository,
    ICountryService
    >
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(GetDatabaseContext());

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton<ICountryRepository, CountryRepository>();


        return alternativeServices;
    }

    protected override CreateCountryDto GetCreateDtoSample()
    {
        return SharedCountryModels.GetSampleCreateDto();
    }

    protected override UpdateCountryDto GetUpdateDtoSample()
    {
        return SharedCountryModels.GetSampleUpdateDto();
    }

    protected override ICountryService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new CountryService(builder.GetRequiredService<ICountryRepository>(), Mapper);
    }
}
