using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.CrudRepositories.ForKids
{
    public class ForKidsRepositoryTest : SharedRepositoryTest<ForKid, IForKidsRepository>
    {
        protected override IForKidsRepository GetRepository(AppDbContext appDbContext)
        {
            return new ForKidsRepository(appDbContext);
        }

        protected override ForKid GetSample()
        {
            return SharedForKidsModels.GetSample();
        }

        protected override ForKid GetSampleForUpdate()
        {
            return SharedForKidsModels.GetSampleForUpdate();
        }
    }
}
