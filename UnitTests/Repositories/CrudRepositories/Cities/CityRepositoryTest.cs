using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.CrudRepositories.Cities;

public class CityRepositoryTest : SharedRepositoryTest<City, ICityRepository>
{
    protected override ICityRepository GetRepository(AppDbContext appDbContext)
    {
        return new CityRepository(appDbContext);
    }

    protected override City GetSample()
    {
        return SharedCityModels.GetSample();
    }

    protected override City GetSampleForUpdate()
    {
        return SharedCityModels.GetSampleForUpdate();
    }
}
