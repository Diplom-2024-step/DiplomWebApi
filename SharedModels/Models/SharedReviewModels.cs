using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Polimorfizms.ReviewablePhotoables;
using AnytourApi.Application.Repositories.Polimorfizms.Reviewables;
using AnytourApi.Application.Services.Models.Reviews;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Reviews;
using AnytourApi.Dtos.Dto.Users;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Polimorfizms;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models;

public class SharedReviewModels : SharedModelsBase, IShareModels<CreateReviewDto, UpdateReviewDto, Review>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<IReviewableRepository, ReviewableRepository>();

        services.AddScoped<IReviewablePhotoableRepository, ReviewablePhotoableRepository>();

        services.AddScoped<IReviewRepository, ReviewRepository>();

        services.AddScoped<IReviewService, ReviewService>();


    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        return await serviceProvider.GetService<IReviewService>().CreateAsync(
            SharedReviewModels.GetSampleCreateDto(),
            cancellationToken
            );
    }

    public static Review GetSample()
    {
        return new Review()
        {
            ReviewablePhotoableId = Guid.NewGuid(),
            Body = "dsadmakfak",
            Score = 0,
            User = SharedUserModels.GetSample()
        };
    }

    public static CreateReviewDto GetSampleCreateDto()
    {
        return new CreateReviewDto()
        {
            ReviewablePhotoableId = Guid.NewGuid(),
            Body = "klamklmkl",
            Score = 0,
            UserId = Guid.NewGuid(),
        };
    }

    public static Review GetSampleForUpdate()
    {
        return new Review()
        {
            ReviewablePhotoableId = Guid.NewGuid(),
            Body = "23dkmqkmdkq",
            Score = 0,
            User = SharedUserModels.GetSampleForUpdate(),
        };
    }

    public static UpdateReviewDto GetSampleUpdateDto()
    {
        return new UpdateReviewDto()
        {
            ReviewablePhotoableId = Guid.NewGuid(),
            Body = "dsalkdklmkl",
            Score = 0,
            UserId = Guid.NewGuid()
        };
    }
}
