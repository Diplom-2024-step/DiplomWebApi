using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.BeachTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.BeachTypes;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models;

public class SharedBeachTypeModels : SharedModelsBase, IShareModels<CreateBeachTypeDto, UpdateBeachTypeDto, BeachType>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<IBeachTypeRepository, BeachTypeRepository>();
        services.AddScoped<IBeachTypeService, BeachTypeService>();
    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var beatchType = SharedBeachTypeModels.GetSampleCreateDto();

        return await serviceProvider.GetService<IBeachTypeService>().CreateAsync(beatchType, cancellationToken);
    }


    public static BeachType GetSample()
    {
        return new BeachType()
        {
            Name = "UserName",
        };
    }

    public static CreateBeachTypeDto GetSampleCreateDto()
    {
        return new CreateBeachTypeDto()
        {
            Name = "test",
        };
    }

    public static BeachType GetSampleForUpdate()
    {
        return new BeachType()
        {
            Name = "Name123"
        };
    }

    public static UpdateBeachTypeDto GetSampleUpdateDto()
    {
        return new UpdateBeachTypeDto()
        {
            Name = "test12",
        };
    }
}
