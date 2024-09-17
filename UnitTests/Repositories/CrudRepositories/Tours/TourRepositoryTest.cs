using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.CrudRepositories.Tours;

public class TourRepositoryTest : SharedRepositoryTest<Tour, ITourRepository>
{
    protected override ITourRepository GetRepository(AppDbContext appDbContext)
    {
        return new TourRepository(appDbContext);
    }

    protected override Tour GetSample()
    {
        return SharedTourModels.GetSample();
    }

    protected override Tour GetSampleForUpdate()
    {
        return SharedTourModels.GetSampleForUpdate();
    }
}
