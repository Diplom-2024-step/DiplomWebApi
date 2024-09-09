using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Relations.BeachTypeHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;

namespace AnytourApi.UnitTests.Services.Relations;

public class BeachTypeHotelRelationServiceTest : SharedRelationServiceTest<
    BeachTypeHotel, IBeachTypeHotelRelationService,
    BeachType, Hotel,
    IBeachTypeRepository, IHotelRepository>
{
    public override BeachType GetFirstModel()
    {
        return SharedBeachTypeModels.GetSample();
    }

    public override IBeachTypeRepository GetFirstRepository(AppDbContext appDbContext)
    {
        return new BeachTypeRepository(appDbContext);
    }

    public override BeachTypeHotel GetRelationModel(Guid firstId, Guid secondId)
    {
        return new BeachTypeHotel()
        {
            FirstId = firstId,
            SecondId = secondId
        };
    }

    public override IBeachTypeHotelRelationService GetRelationService(AppDbContext appDbContext)
    {
        return new BeachTypeHotelRelationService(
            new BeachTypeHotelRelationRepository(appDbContext)
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
