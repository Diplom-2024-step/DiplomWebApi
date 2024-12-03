using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Relations.InRoomHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;

namespace AnytourApi.UnitTests.Services.Relations;

public class InRoomHotelRelationServiceTest : SharedRelationServiceTest<
    InRoomHotel, IInRoomHotelRelationService,
    InRoom, Hotel,
    IInRoomRepository, IHotelRepository>
{
    public override InRoom GetFirstModel()
    {
        return SharedInRoomModels.GetSample();
    }

    public override IInRoomRepository GetFirstRepository(AppDbContext appDbContext)
    {
        return new InRoomRepository(appDbContext);
    }

    public override InRoomHotel GetRelationModel(Guid firstId, Guid secondId)
    {
        return new InRoomHotel()
        {
            FirstId = firstId,
            SecondId = secondId
        };
    }

    public override IInRoomHotelRelationService GetRelationService(AppDbContext appDbContext)
    {
        return new InRoomHotelRelationService(
            new InRoomHotelRelationRepository(appDbContext)
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
