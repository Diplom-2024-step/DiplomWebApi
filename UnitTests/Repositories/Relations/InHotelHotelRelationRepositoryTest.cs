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

public class InHotelHotelRelationRepositoryTest : SharedRelationRepositoryTest<
    InHotelHotel, InHotel, Hotel,
    IInHotelHotelRelationRepository, IInHotelRepository, IHotelRepository
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

    public override IInHotelHotelRelationRepository GetRelationRepository(AppDbContext appDbContext)
    {
        return new InHotelHotelRelationRepository(appDbContext);
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
