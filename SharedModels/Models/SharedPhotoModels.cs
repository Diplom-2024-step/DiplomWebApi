using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Photos;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Photos;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.Infrastructure.FileHelper;
using AnytourApi.SharedModels.MyFakers;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models;

public class SharedPhotoModels : SharedModelsBase, IShareModels<CreatePhotoDto, UpdatePhotoDto, Photo>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<IPhotoRepository, PhotoRepository>();

        services.AddScoped<IPhotoService, PhotoService>();

        services.AddScoped<IFileHelper, FileHelper>();

    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        return await serviceProvider.GetService<IPhotoService>().CreateAsync(
            SharedPhotoModels.GetSampleCreateDto(),
            cancellationToken
            );
    }

    public static Photo GetSample()
    {
        return new Photo()
        {
            Height = 128,
            Width = 128,
            Path = "C:test/test/Denys",
            PhotoableId = Guid.NewGuid(),
        };
    }

    public static CreatePhotoDto GetSampleCreateDto()
    {
        return new CreatePhotoDto()
        {
            PhotoableId = Guid.NewGuid(),
            Photo = MyDataFaker.GetFakeImage()
        };
    }

    public static Photo GetSampleForUpdate()
    {
        return new Photo()
        {
            Height = 128,
            Path = "C:dsaf",
            PhotoableId = Guid.NewGuid(),
            Width = 128,
        };
    }

    public static UpdatePhotoDto GetSampleUpdateDto()
    {
        return new UpdatePhotoDto()
        {
            PhotoableId = Guid.NewGuid(),
            Photo = MyDataFaker.GetFakeImage()
        };
    }
}
