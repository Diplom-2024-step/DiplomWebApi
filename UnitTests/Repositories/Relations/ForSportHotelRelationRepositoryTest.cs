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

public class ForSportHotelRelationRepositoryTest : SharedRelationRepositoryTest<
    ForSportHotel, ForSport, Hotel,
    IForSportHotelRelationRepository, IForSportRepository, IHotelRepository>
{
    public override ForSport GetFirstModel()
    {
        return SharedForSportModels.GetSample();
    }

    public override IForSportRepository GetFirstRepository(AppDbContext appDbContext)
    {
        return new ForSportRepository(appDbContext);
    }

    public override ForSportHotel GetRelationModel(Guid firstId, Guid secondId)
    {
        return new ForSportHotel()
        {
            FirstId = firstId,
            SecondId = secondId
        };
    }

    public override IForSportHotelRelationRepository GetRelationRepository(AppDbContext appDbContext)
    {
        return new ForSportHotelRelationRepository(appDbContext);
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
