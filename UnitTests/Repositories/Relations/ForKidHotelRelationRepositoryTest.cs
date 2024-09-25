using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.Relations;

public class ForKidHotelRelationRepositoryTest : SharedRelationRepositoryTest<
    ForKidHotel, ForKid, Hotel,
    IForKidHotelRelationRepository, IForKidsRepository, IHotelRepository>
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

    public override IForKidHotelRelationRepository GetRelationRepository(AppDbContext appDbContext)
    {
        return new ForKidHotelRelationRepository(appDbContext);
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
