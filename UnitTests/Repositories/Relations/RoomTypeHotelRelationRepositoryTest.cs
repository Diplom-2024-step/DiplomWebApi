using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;
using Xunit.Sdk;

namespace AnytourApi.UnitTests.Repositories.Relations;

public class RoomTypeHotelRelationRepositoryTest : SharedRelationRepositoryTest<
    RoomTypeHotel, RoomType, Hotel,
    IRoomTypeHotelRelationRepository, IRoomTypeRepository, IHotelRepository>
{
    public override RoomType GetFirstModel()
    {
        return SharedRoomTypeModels.GetSample();
    }

    public override IRoomTypeRepository GetFirstRepository(AppDbContext appDbContext)
    {
        return new RoomTypeRepository(appDbContext);
    }

    public override RoomTypeHotel GetRelationModel(Guid firstId, Guid secondId)
    {
        return new RoomTypeHotel()
        {
            FirstId = firstId,
            SecondId = secondId
        };
    }

    public override IRoomTypeHotelRelationRepository GetRelationRepository(AppDbContext appDbContext)
    {
        return new RoomTypeHotelRelationRepository(appDbContext);
    }

    public override Hotel GetSecondModel()
    {
        return SharedHotelModels.GetSample();
    }

    public override IHotelRepository GetSecondRepository(AppDbContext appDbContext)
    {
        return new HotelRepository(appDbContext);
    }
}
