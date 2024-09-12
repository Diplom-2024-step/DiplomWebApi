using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.DietTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.DietTypes;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;


namespace AnytourApi.SharedModels.Models;

public class SharedDietTypeModels : SharedModelsBase, IShareModels<CreateDietTypeDto, UpdateDietTypeDto, DietType>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<IDietTypeRepository, DietTypeRepository>();
        services.AddScoped<IDietTypeService, DietTypeService>();
    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var dietType = SharedDietTypeModels.GetSampleCreateDto();

        return await serviceProvider.GetService<IDietTypeService>().CreateAsync(dietType, cancellationToken);
    }


    public static DietType GetSample()
    {
        return new DietType()
        {
            Name = "UserName",
        };
    }

    public static CreateDietTypeDto GetSampleCreateDto()
    {
        return new CreateDietTypeDto()
        {
            Name = "test",
        };
    }

    public static DietType GetSampleForUpdate()
    {
        return new DietType()
        {
            Name = "Name123"
        };
    }

    public static UpdateDietTypeDto GetSampleUpdateDto()
    {
        return new UpdateDietTypeDto()
        {
            Name = "test12",
        };
    }
}
