using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.BeachTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.BeachTypes;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.BeachTypes;

public class BeachTypeServiceTest : SharedServiceTest<
    GetBeachTypeDto,
    CreateBeachTypeDto,
    UpdateBeachTypeDto,
    BeachType,
    GetBeachTypeDto,
    IBeachTypeRepository,
    IBeachTypeService>
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(GetDatabaseContext());

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton<IBeachTypeRepository, BeachTypeRepository>();

        return alternativeServices;
    }

    protected override CreateBeachTypeDto GetCreateDtoSample()
    {
        return SharedBeachTypeModels.GetSampleCreateDto();
    }

    protected override UpdateBeachTypeDto GetUpdateDtoSample()
    {
        return SharedBeachTypeModels.GetSampleUpdateDto();
    }

    protected override IBeachTypeService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new BeachTypeService(builder.GetRequiredService<IBeachTypeRepository>(), Mapper);
    }
}
