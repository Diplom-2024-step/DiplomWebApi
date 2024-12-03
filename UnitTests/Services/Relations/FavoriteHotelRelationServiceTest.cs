using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Users;
using AnytourApi.Application.Services.Relations.FavoriteHotels;
using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;

namespace AnytourApi.UnitTests.Services.Relations;

public class FavoriteHotelRelationServiceTest : SharedRelationServiceTest<
    FavoriteHotel, IFavoriteHotelRelationService,
    Hotel, User,
    IHotelRepository, IUserRepository>
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

    public override IFavoriteHotelRelationService GetRelationService(AppDbContext appDbContext)
    {
        return new FavoriteHotelRelationService(
            new FavoriteHotelRelationRepository(appDbContext)
            );
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