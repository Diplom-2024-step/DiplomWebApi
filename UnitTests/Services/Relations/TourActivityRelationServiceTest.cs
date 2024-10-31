using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Relations.TourActivities;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;

namespace AnytourApi.UnitTests.Services.Relations;

public class TourActivityRelationServiceTest : SharedRelationServiceTest<
    TourActivity, ITourActivityRelationService,
    Tour, Activity,
    ITourRepository, IActivityRepository>
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

    public override ITourActivityRelationService GetRelationService(AppDbContext appDbContext)
    {
        return new TourActivityRelationService(
            new TourActivityRelationRepository(appDbContext)
            );
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