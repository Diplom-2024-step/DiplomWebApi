using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Polimorfizms.Photoables;
using AnytourApi.Application.Repositories.Polimorfizms.ReviewablePhotoables;
using AnytourApi.Application.Repositories.Polimorfizms.Reviewables;
using AnytourApi.Application.Services.Models.Photos;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Polimorfizms;
using AnytourApi.Infrastructure.FileHelper;
using AnytourApi.SharedModels.MockObjects;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models;

public class SharedReviewablePhotoableModels : SharedModelsBase
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<IPhotoableRepository, PhotoableRepository>();

        services.AddScoped<IReviewableRepository, ReviewableRepository>();

        services.AddScoped<IReviewablePhotoableRepository, ReviewablePhotoableRepository>();

        services.AddScoped<IFileHelper, FileHelperMock>();

        services.AddScoped<IPhotoRepository, PhotoRepository>();

        services.AddScoped<IPhotoService, PhotoService>();
    }

    public static ReviewablePhotoable GetSample()
    {
        return new ReviewablePhotoable()
        {
            Photos = [
                SharedPhotoModels.GetSample()
                ],
            Reviews = [
                SharedReviewModels.GetSample()
                ],
        };
    }

    public static ReviewablePhotoable GetSampleForUpdate()
    {
        return new ReviewablePhotoable()
        {
            Photos = [
                SharedPhotoModels.GetSampleForUpdate(),
                SharedPhotoModels.GetSample()
                ],
            Reviews = [

                SharedReviewModels.GetSample(),
                SharedReviewModels.GetSampleForUpdate(),
                ],
        };
    }

}