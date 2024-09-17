using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Polimorfizms.Photoables;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.CrudRepositories.Photos;

public class PhotoRepositoryTest : SharedRepositoryTest<Photo, IPhotoRepository>
{
    protected override IPhotoRepository GetRepository(AppDbContext appDbContext)
    {
        return new PhotoRepository(appDbContext);
    }

    protected override Photo GetSample()
    {
        return SharedPhotoModels.GetSample();
    }

    protected override Photo GetSampleForUpdate()
    {
        return SharedPhotoModels.GetSampleForUpdate();
    }
}
