using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Repositories.Users;
using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.Relations;

class FavoriteHotelRelationRepositoryTest : SharedRelationRepositoryTest<
    FavoriteHotel, Hotel, User,
    IFavoriteHotelRelationRepository, IHotelRepository, IUserRepository>
{
    public override Hotel GetFirstModel()
    {
        return SharedHotelModels.GetSample();
    }

    public override IHotelRepository GetFirstRepository(AppDbContext appDbContext)
    {
        return new HotelRepository(appDbContext);
    }

    public override FavoriteHotel GetRelationModel(Guid firstId, Guid secondId)
    {
        return new FavoriteHotel()
        {
            FirstId = firstId,
            SecondId = secondId
        };
    }

    public override IFavoriteHotelRelationRepository GetRelationRepository(AppDbContext appDbContext)
    {
        return new FavoriteHotelRelationRepository(appDbContext);
    }

    public override User GetSecondModel()
    {
        return SharedUserModels.GetSample();
    }

    public override IUserRepository GetSecondRepository(AppDbContext appDbContext)
    {
        return new UserRepository(appDbContext, GetUserManager(appDbContext));
    }
}
