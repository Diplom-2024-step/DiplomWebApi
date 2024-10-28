using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Activities;
using AnytourApi.Application.Services.Models.Photos;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Activities;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.Activities;

public class ActivityServiceTest : SharedServiceTest<
    GetActivityDto,
    CreateActivityDto,
    UpdateActivityDto,
    Activity,
    GetActivityDto,
    IActivityRepository,
    IActivityService>
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(GetDatabaseContext());

        alternativeServices.AddSingleton(Mapper);


        SharedActivityModels.AddAllDependencies(alternativeServices);


        return alternativeServices;
    }

    protected override CreateActivityDto GetCreateDtoSample()
    {
        return SharedActivityModels.GetSampleCreateDto();
    }

    protected override UpdateActivityDto GetUpdateDtoSample()
    {
        return SharedActivityModels.GetSampleUpdateDto();
    }

    protected override IActivityService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new ActivityService(builder.GetRequiredService<IActivityRepository>(), builder.GetRequiredService<IPhotoService>(), Mapper);
    }
}
