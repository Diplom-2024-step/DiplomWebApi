using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Activities;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Activities;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models;

public class SharedActivityModels : SharedModelsBase, IShareModels<CreateActivityDto, UpdateActivityDto, Activity>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<IActivityRepository, ActivityRepository>();

        services.AddScoped<IActivityService, ActivityService>();
    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var activity = SharedActivityModels.GetSampleCreateDto();

        return await serviceProvider.GetService<IActivityService>().CreateAsync(activity, cancellationToken);

    }

    public static Activity GetSample()
    {
        return new Activity()
        {
            Name = "ActivityName",
            Description="fsfa",
            Photos = [SharedPhotoModels.GetSample()],
            Reviews = [SharedReviewModels.GetSample()],
        };
    }

    public static CreateActivityDto GetSampleCreateDto()
    {
        return new CreateActivityDto()
        {
            Name = "test",
            Description="fsfa"
        };
    }

    public static Activity GetSampleForUpdate()
    {
        return new Activity()
        {
            Name = "Name123",
            Description = "fsfa",
            Photos = [SharedPhotoModels.GetSampleForUpdate()],
            Reviews = [SharedReviewModels.GetSampleForUpdate()],
        };
    }

    public static UpdateActivityDto GetSampleUpdateDto()
    {
        return new UpdateActivityDto()
        {
            Name = "test12",
            Description = "fsfa"
        };
    }
}
