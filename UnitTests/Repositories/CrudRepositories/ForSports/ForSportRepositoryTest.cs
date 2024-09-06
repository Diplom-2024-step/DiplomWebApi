using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.CrudRepositories.ForSports;

public class ForSportRepositoryTest : SharedRepositoryTest<ForSport, IForSportRepository>
{
    protected override IForSportRepository GetRepository(AppDbContext appDbContext)
    {
        return new ForSportRepository(appDbContext);
    }

    protected override ForSport GetSample()
    {
        return SharedForSportModels.GetSample();
    }

    protected override ForSport GetSampleForUpdate()
    {
        return SharedForSportModels.GetSampleForUpdate();
    }
}

