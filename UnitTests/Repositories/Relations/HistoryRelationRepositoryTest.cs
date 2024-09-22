using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Repositories.Users;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.Domain.Models;
using AnytourApi.UnitTests.Shared.Repositories;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.EfPersistence.Repositories;
using AnytourApi.SharedModels.Models;
namespace AnytourApi.UnitTests.Repositories.Relations;

public class HistoryRelationRepositoryTest : SharedRelationRepositoryTest<
    History, User, Tour,
    IHistoryRelationRepository, IUserRepository, ITourRepository>
{
    public override User GetFirstModel()
    {
        return SharedUserModels.GetSample();
    }

    public override IUserRepository GetFirstRepository(AppDbContext appDbContext)
    {
        return new UserRepository(appDbContext, GetUserManager(appDbContext));       
    }

    public override History GetRelationModel(Guid firstId, Guid secondId)
    {
        return new History()
        {
            FirstId = firstId,
            SecondId = secondId
        };
    }

    public override IHistoryRelationRepository GetRelationRepository(AppDbContext appDbContext)
    {
        return new HistoryRelationRepository(appDbContext);
    }

    public override Tour GetSecondModel()
    {
        return SharedTourModels.GetSample();
    }

    public override ITourRepository GetSecondRepository(AppDbContext appDbContext)
    {
        return new TourRepository(appDbContext);
    }
}
