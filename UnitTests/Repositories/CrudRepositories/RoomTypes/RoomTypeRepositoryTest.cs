using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.CrudRepositories.RoomTypes;

public class RoomTypeRepositoryTest : SharedRepositoryTest<RoomType, IRoomTypeRepository>
{
    protected override IRoomTypeRepository GetRepository(AppDbContext appDbContext)
    {
        return new RoomTypeRepository(appDbContext);
    }

    protected override RoomType GetSample()
    {
        return SharedRoomTypeModels.GetSample();
    }

    protected override RoomType GetSampleForUpdate()
    {
        return SharedRoomTypeModels.GetSampleForUpdate();
    }
}
