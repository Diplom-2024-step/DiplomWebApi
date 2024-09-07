using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Relations.InHotelHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;

namespace AnytourApi.UnitTests.Services.Relations;

public class InHotelHotelRelationServiceTest : SharedRelationServiceTest<
    InHotelHotel, IInHotelHotelRelationService,
    InHotel, Hotel,
    IInHotelRepository, IHotelRepository
    >
{
    public override InHotel GetFirstModel()
    {
        return SharedInHotelModels.GetSample();
    }

    public override IInHotelRepository GetFirstRepository(AppDbContext appDbContext)
    {
        return new InHotelRepository(appDbContext);
    }

    public override InHotelHotel GetRelationModel(Guid firstId, Guid secondId)
    {
        return new InHotelHotel()
        {
            FirstId = firstId,
            SecondId = secondId
        };
    }

    public override IInHotelHotelRelationService GetRelationService(AppDbContext appDbContext)
    {
        return new InHotelHotelRelationService(
            new InHotelHotelRelationRepository(appDbContext)
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
