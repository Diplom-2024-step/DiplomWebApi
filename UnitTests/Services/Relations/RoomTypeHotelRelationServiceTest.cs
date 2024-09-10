using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Relations.RoomTypeHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;

namespace AnytourApi.UnitTests.Services.Relations;

public class RoomTypeHotelRelationServiceTest : SharedRelationServiceTest<
    RoomTypeHotel, IRoomTypeHotelRelationService,
    RoomType, Hotel,
    IRoomTypeRepository, IHotelRepository>
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

    public override IRoomTypeHotelRelationService GetRelationService(AppDbContext appDbContext)
    {
        return new RoomTypeHotelRelationService(
            new RoomTypeHotelRelationRepository(appDbContext)
            );
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
