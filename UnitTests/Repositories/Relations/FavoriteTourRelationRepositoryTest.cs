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

public class FavoriteTourRelationRepositoryTest : SharedRelationRepositoryTest<
    FavoriteTour, Tour, User,
    IFavoriteTourRelationRepository, ITourRepository, IUserRepository>
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

    public override IFavoriteTourRelationRepository GetRelationRepository(AppDbContext appDbContext)
    {
        return new FavoriteTourRelationRepository(appDbContext);
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
