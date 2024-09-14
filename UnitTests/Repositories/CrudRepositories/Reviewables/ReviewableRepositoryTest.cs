using AnytourApi.Application.Repositories.Polimorfizms.Reviewables;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Polimorfizms;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.CrudRepositories.Reviewables;

public class ReviewableRepositoryTest : SharedRepositoryTest<Reviewable, IReviewableRepository>
{
    protected override IReviewableRepository GetRepository(AppDbContext appDbContext)
    {
        return new ReviewableRepository(
            appDbContext
            );
    }

    protected override Reviewable GetSample()
    {
        return SharedReviewableModels.GetSample();
    
    }

    protected override Reviewable GetSampleForUpdate()
    {
        return SharedReviewableModels.GetSampleForUpdate();
    }
}