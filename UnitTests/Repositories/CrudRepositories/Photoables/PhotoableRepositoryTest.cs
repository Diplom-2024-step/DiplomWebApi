using AnytourApi.Application.Repositories.Polimorfizms.Photoables;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Polimorfizms;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;
using Xunit.Sdk;

namespace AnytourApi.UnitTests.Repositories.CrudRepositories.Photoables;

public class PhotoableRepositoryTest : SharedRepositoryTest<Photoable, IPhotoableRepository>
{
    protected override IPhotoableRepository GetRepository(AppDbContext appDbContext)
    {
        return new PhotoableRepository(
            appDbContext
            );
    }

    protected override Photoable GetSample()
    {
        return new Photoable()
        {
            Photos =
            [
                SharedPhotoModels.GetSample(),
                ]

        };
    }

    protected override Photoable GetSampleForUpdate()
    {
        return new Photoable()
        {
            Photos =
            [
                SharedPhotoModels.GetSampleForUpdate(),
                SharedPhotoModels.GetSample()
                ]


        };
    }
}
