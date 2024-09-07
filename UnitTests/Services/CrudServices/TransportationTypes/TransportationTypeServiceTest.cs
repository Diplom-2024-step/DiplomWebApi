using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.TransportationTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.TransportationTypes;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.TransportationTypes;

public class TransportationTypeServiceTest : SharedServiceTest<
    GetTransportationTypeDto,
    CreateTransportationTypeDto,
    UpdateTransportationTypeDto,
    TransportationType,
    GetTransportationTypeDto,
    ITransportationTypeRepository,
    ITransportationTypeService
    >
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(GetDatabaseContext());

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton<ITransportationTypeRepository, TransportationTypeRepository>();


        return alternativeServices;
    }

    protected override CreateTransportationTypeDto GetCreateDtoSample()
    {
        return SharedTransportationTypeModels.GetSampleCreateDto();
    }

    protected override UpdateTransportationTypeDto GetUpdateDtoSample()
    {
        return SharedTransportationTypeModels.GetSampleUpdateDto();
    }

    protected override ITransportationTypeService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new TransportationTypeService(builder.GetRequiredService<ITransportationTypeRepository>(), Mapper);
    }
}
