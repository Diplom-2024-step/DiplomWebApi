using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Users;
using AnytourApi.Application.Services.Relations.DietTypeHotels;
using AnytourApi.Application.Services.Relations.FavoriteTours;
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

public class FavoriteTourRelationServiceTest : SharedRelationServiceTest<
    FavoriteTour, IFavoriteTourRelationService,
    Tour, User,
    ITourRepository, IUserRepository>
{
    public override Tour GetFirstModel()
    {
        return SharedTourModels.GetSample();
    }

    public override ITourRepository GetFirstRepository(AppDbContext appDbContext)
    {
        return new TourRepository(appDbContext);
    }

    public override FavoriteTour GetRelationModel(Guid firstId, Guid secondId)
    {
        return new FavoriteTour()
        {
            FirstId = firstId,
            SecondId = secondId
        };
    }

    public override IFavoriteTourRelationService GetRelationService(AppDbContext appDbContext)
    {
        return new FavoriteTourRelationService(
            new FavoriteTourRelationRepository(appDbContext)
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
