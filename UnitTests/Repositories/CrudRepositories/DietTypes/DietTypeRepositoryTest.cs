using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;


namespace AnytourApi.UnitTests.Repositories.CrudRepositories.DietTypes;

public class DietTypeRepositoryTest : SharedRepositoryTest<DietType, IDietTypeRepository>
{
    protected override IDietTypeRepository GetRepository(AppDbContext appDbContext)
    {
        return new DietTypeRepository(appDbContext);
    }

    protected override DietType GetSample()
    {
        return SharedDietTypeModels.GetSample();
    }

    protected override DietType GetSampleForUpdate()
    {
        return SharedDietTypeModels.GetSampleForUpdate();
    }
}
