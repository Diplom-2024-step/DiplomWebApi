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

class DietTypeHotelRepositoryTest : SharedRelationRepositoryTest<
    DietTypeHotel, DietType, Hotel,
    IDietTypeHotelRelationRepository, IDietTypeRepository, IHotelRepository>
{

    public override DietType GetFirstModel()
    {
        return SharedDietTypeModels.GetSample();
    }

    public override IDietTypeRepository GetFirstRepository(AppDbContext appDbContext)
    {
        return new DietTypeRepository(appDbContext);
    }

    public override DietTypeHotel GetRelationModel(Guid firstId, Guid secondId)
    {
        return new DietTypeHotel()
        {
            FirstId = firstId,
            SecondId = secondId
        };
    }

    public override IDietTypeHotelRelationRepository GetRelationRepository(AppDbContext appDbContext)
    {
        return new DietTypeHotelRelationRepository(appDbContext);
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
