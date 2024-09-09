using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.Activities;

public class ActivityRepositoryTest : SharedRepositoryTest<Activity, IActivityRepository>
{
    protected override IActivityRepository GetRepository(AppDbContext appDbContext)
    {
        return new ActivityRepository(appDbContext);
    }

    protected override Activity GetSample()
    {
        return SharedActivityModels.GetSample();
    }

    protected override Activity GetSampleForUpdate()
    {
        return SharedActivityModels.GetSampleForUpdate();
    }
}
