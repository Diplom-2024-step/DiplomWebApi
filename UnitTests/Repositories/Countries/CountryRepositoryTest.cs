using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.Countries;

public class CountryRepositoryTest : SharedRepositoryTest<Country, ICountryRepository>
{
    protected override ICountryRepository GetRepository(AppDbContext appDbContext)
    {
        return new CountryRepository(appDbContext);
    }

    protected override Country GetSample()
    {
        return SharedCountryModels.GetSample();
    }

    protected override Country GetSampleForUpdate()
    {
        return SharedCountryModels.GetSampleForUpdate();
    }
}
