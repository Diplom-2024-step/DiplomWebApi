using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.BeachTypes;

public class BeachTypeRepositoryTest : SharedRepositoryTest<BeachType, IBeachTypeRepository>
{
    protected override IBeachTypeRepository GetRepository(AppDbContext appDbContext)
    {
        return new BeachTypeRepository(appDbContext);
    }

    protected override BeachType GetSample()
    {
        return SharedBeachTypeModels.GetSample();
    }

    protected override BeachType GetSampleForUpdate()
    {
        return SharedBeachTypeModels.GetSampleForUpdate();
    }
}
