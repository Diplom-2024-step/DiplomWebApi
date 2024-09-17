using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Polimorfizms.Photoables;
using AnytourApi.Application.Services.Models.Photos;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Photos;
using AnytourApi.EfPersistence.Data;
using AnytourApi.Infrastructure.FileHelper;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.Photos;

public class PhotoServiceTest : SharedServiceTest<GetPhotoDto, CreatePhotoDto, UpdatePhotoDto, Photo, GetPhotoDto, IPhotoRepository, IPhotoService>
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        SharedPhotoModels.AddAllDependencies(alternativeServices);
        alternativeServices.AddSingleton(GetDatabaseContext());

        alternativeServices.AddSingleton(Mapper);

        return alternativeServices;
    }

    protected override CreatePhotoDto GetCreateDtoSample()
    {
        return SharedPhotoModels.GetSampleCreateDto();
    }

    protected override IPhotoService GetService(IServiceCollection alternativeServices)
    {
        var provider = alternativeServices.BuildServiceProvider();

        return new PhotoService(
            provider.GetService<IPhotoRepository>(),
            provider.GetService<IFileHelper>(),
            Mapper
            );
    }

    protected override UpdatePhotoDto GetUpdateDtoSample()
    {
        return SharedPhotoModels.GetSampleUpdateDto();
    }
}
