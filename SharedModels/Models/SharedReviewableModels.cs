using AnytourApi.Application.Repositories.Polimorfizms.Reviewables;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Polimorfizms;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models;

public class SharedReviewableModels : SharedModelsBase
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<IReviewableRepository, ReviewableRepository>();
    }

    public static Reviewable GetSample()
    {
        return new Reviewable()
        {
            Reviews = [
                SharedReviewModels.GetSample()
                ]
        };
    }

    public static Reviewable GetSampleForUpdate()
    {
        return new Reviewable()
        {
            Reviews = [
                SharedReviewModels.GetSampleForUpdate(),
                SharedReviewModels.GetSample()
                ]
        };    }

}