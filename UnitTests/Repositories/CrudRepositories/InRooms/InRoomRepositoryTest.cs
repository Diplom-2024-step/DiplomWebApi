using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.CrudRepositories.InRooms
{
    public class InRoomRepositoryTest : SharedRepositoryTest<InRoom, IInRoomRepository>
    {
        protected override IInRoomRepository GetRepository(AppDbContext appDbContext)
        {
            return new InRoomRepository(appDbContext);
        }

        protected override InRoom GetSample()
        {
            return SharedInRoomModels.GetSample();
        }

        protected override InRoom GetSampleForUpdate()
        {
            return SharedInRoomModels.GetSampleForUpdate();
        }
    }
}
