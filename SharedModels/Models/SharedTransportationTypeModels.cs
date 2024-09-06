using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.TransportationTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.TransportationTypes;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models;

public class SharedTransportationTypeModels : SharedModelsBase, IShareModels<CreateTransportationTypeDto, UpdateTransportationTypeDto, TransportationType>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<ITransportationTypeRepository, TransportationTypeRepository>();

        services.AddScoped<ITransportationTypeService, TransportationTypeService>();
    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var transportationType = SharedTransportationTypeModels.GetSampleCreateDto();

        return await serviceProvider.GetService<ITransportationTypeService>().CreateAsync(transportationType, cancellationToken);

    }

    public static TransportationType GetSample()
    {
        return new TransportationType()
        {
            Name = "Name",
        };
    }

    public static CreateTransportationTypeDto GetSampleCreateDto()
    {
        return new CreateTransportationTypeDto()
        {
            Name = "test",
        };
    }

    public static TransportationType GetSampleForUpdate()
    {
        return new TransportationType()
        {
            Name = "Name123"
        };
    }

    public static UpdateTransportationTypeDto GetSampleUpdateDto()
    {
        return new UpdateTransportationTypeDto()
        {
            Name = "test12",
        };
    }
}
