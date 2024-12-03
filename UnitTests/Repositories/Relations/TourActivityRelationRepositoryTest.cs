using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.Relations;

class TourActivityRelationRepositoryTest : SharedRelationRepositoryTest<
    TourActivity, Tour, Activity,
    ITourActivityRelationRepository, ITourRepository, IActivityRepository>
{
    public override Tour GetFirstModel()
    {
        return SharedTourModels.GetSample();
    }

    public override ITourRepository GetFirstRepository(AppDbContext appDbContext)
    {
        return new TourRepository(appDbContext);
    }

    public override TourActivity GetRelationModel(Guid firstId, Guid secondId)
    {
        return new TourActivity()
        {
            FirstId = firstId,
            SecondId = secondId
        };
    }

    public override ITourActivityRelationRepository GetRelationRepository(AppDbContext appDbContext)
    {
        return new TourActivityRelationRepository(appDbContext);
    }

    public override Activity GetSecondModel()
    {
        return SharedActivityModels.GetSample();
    }

    public override IActivityRepository GetSecondRepository(AppDbContext appDbContext)
    {
        return new ActivityRepository(appDbContext);
    }
}
