using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Countries;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Countries;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models;

public class SharedCountryModels : SharedModelsBase, IShareModels<CreateCountryDto, UpdateCountryDto, Country>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<ICountryRepository, CountryRepository>();

        services.AddScoped<ICountryService, CountryService>();
    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var country = SharedCountryModels.GetSampleCreateDto();

        return await serviceProvider.GetService<ICountryService>().CreateAsync(country, cancellationToken);
            
     }

    public static Country GetSample()
    {
        return new Country()
        {
            Icon = "tesfa",
            Name = "UserName",
        };
    }

    public static CreateCountryDto GetSampleCreateDto()
    {
        return new CreateCountryDto()
        {
            Icon = "Test",
            Name = "test",
        };
    }

    public static Country GetSampleForUpdate()
    {
        return new Country()
        {
            Icon = "test123",
            Name = "Name123"
        };
    }

    public static UpdateCountryDto GetSampleUpdateDto()
    {
        return new UpdateCountryDto() 
        {
            Icon = "test12",
            Name = "test12",
        };
    }
}
