using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Countries;
using AnytourApi.Application.Services.Models.ForSports;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ForSports;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models;

public class SharedForSportModels : SharedModelsBase, IShareModels<CreateForSportDto, UpdateForSportDto, ForSport>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<IForSportRepository, ForSportRepository>();

        services.AddScoped<IForSportService, ForSportService>();

    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var forSport = SharedForSportModels.GetSampleCreateDto();

        return await serviceProvider.GetService<IForSportService>().CreateAsync(forSport, cancellationToken);
    }

    public static ForSport GetSample()
    {
        return new ForSport()
        {
            Name = "UserName",
        };
    }

    public static CreateForSportDto GetSampleCreateDto()
    {
        return new CreateForSportDto()
        {
            Name = "test99",
        };
    }

    public static ForSport GetSampleForUpdate()
    {
        return new ForSport()
        {
            Name = "Name1234"
        };
    }

    public static UpdateForSportDto GetSampleUpdateDto()
    {
        return new UpdateForSportDto()
        {
            Name = "test125",
        };
    }
}

