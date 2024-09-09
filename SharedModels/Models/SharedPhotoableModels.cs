using AnytourApi.Application.Repositories.Polimorfizms.Photoables;
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
    }

    public static Photoable GetSample()
    {
        return new Photoable()
        {
            Photos = [

                ]
        };
    }

    public static Photoable GetSampleCreateDto()
    {
        throw new NotImplementedException();
    }

    public static Photoable GetSampleForUpdate()
    {
        throw new NotImplementedException();
    }

    public static Photoable GetSampleUpdateDto()
    {
        throw new NotImplementedException();
    }
}
