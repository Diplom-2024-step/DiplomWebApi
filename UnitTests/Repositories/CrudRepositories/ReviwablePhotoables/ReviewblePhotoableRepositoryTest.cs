using AnytourApi.Application.Repositories.Polimorfizms.ReviewablePhotoables;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Polimorfizms;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.CrudRepositories.ReviwablePhotoables;

public class ReviewblePhotoableRepositoryTest : SharedRepositoryTest<ReviewablePhotoable, IReviewablePhotoableRepository>
{

    protected override IReviewablePhotoableRepository GetRepository(AppDbContext appDbContext)
    {
        return new ReviewablePhotoableRepository(
            appDbContext
            );
    }

    protected override ReviewablePhotoable GetSample()
    {
        return SharedReviewablePhotoableModels.GetSample();
    
    }

    protected override ReviewablePhotoable GetSampleForUpdate()
    {
        return SharedReviewablePhotoableModels.GetSampleForUpdate();
    }
}