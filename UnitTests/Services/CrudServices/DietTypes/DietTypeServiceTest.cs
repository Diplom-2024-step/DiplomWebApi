using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.DietTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.DietTypes;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.DietTypes;

public class DietTypeServiceTest : SharedServiceTest<
    GetDietTypeDto,
    CreateDietTypeDto,
    UpdateDietTypeDto,
    DietType,
    GetDietTypeDto,
    IDietTypeRepository,
    IDietTypeService>
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(GetDatabaseContext());

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton<IDietTypeRepository, DietTypeRepository>();


        return alternativeServices;
    }

    protected override CreateDietTypeDto GetCreateDtoSample()
    {
        return SharedDietTypeModels.GetSampleCreateDto();
    }

    protected override UpdateDietTypeDto GetUpdateDtoSample()
    {
        return SharedDietTypeModels.GetSampleUpdateDto();
    }

    protected override IDietTypeService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new DietTypeService(builder.GetRequiredService<IDietTypeRepository>(), Mapper);
    }
}
