using AnytourApi.Application.Repositories.Polimorfizms.Photoables;
using AnytourApi.Application.Repositories.Polimorfizms.ReviewablePhotoables;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.EfPersistence.Repositories.Polimorfizms;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models;

public class SharedPhotoableModels : SharedModelsBase
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<IPhotoableRepository, PhotoableRepository>();

        services.AddScoped<IReviewablePhotoableRepository, ReviewablePhotoableRepository>();
    }

    public static Photoable GetSample()
    {
        return new Photoable()
        {
            Photos = [
                SharedPhotoModels.GetSample()
                ]
        };
    }

    public static Photoable GetSampleForUpdate()
    {
        return new Photoable()
        {
            Photos = [
                SharedPhotoModels.GetSampleForUpdate(),
                SharedPhotoModels.GetSample()
                ]
        };
    }

}
