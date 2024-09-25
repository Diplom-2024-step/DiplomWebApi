using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Relations.ForKidHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;

namespace AnytourApi.UnitTests.Services.Relations;

public class ForKidHotelRelationServiceTest : SharedRelationServiceTest<
    ForKidHotel, IForKidHotelRelationService,
    ForKid, Hotel,
    IForKidsRepository, IHotelRepository>
{
    public override ForKid GetFirstModel()
    {
        return SharedForKidsModels.GetSample();
    }

    public override IForKidsRepository GetFirstRepository(AppDbContext appDbContext)
    {
        return new ForKidsRepository(appDbContext);
    }

    public override ForKidHotel GetRelationModel(Guid firstId, Guid secondId)
    {
        return new ForKidHotel()
        {
            FirstId = firstId,
            SecondId = secondId
        };
    }

    public override IForKidHotelRelationService GetRelationService(AppDbContext appDbContext)
    {
        return new ForKidHotelRelationService(
            new ForKidHotelRelationRepository(appDbContext)
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
