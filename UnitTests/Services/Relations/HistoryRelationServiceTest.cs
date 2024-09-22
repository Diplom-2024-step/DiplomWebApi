using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Users;
using AnytourApi.Application.Services.Relations.Histories;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.Domain.Models;
using AnytourApi.UnitTests.Shared.Services;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.EfPersistence.Repositories;
using AnytourApi.SharedModels.Models;

namespace AnytourApi.UnitTests.Services.Relations;

public class HistoryRelationServiceTest : SharedRelationServiceTest<
    History, IHistoryRelationService,
    User, Tour,
    IUserRepository, ITourRepository>
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

    public override IHistoryRelationService GetRelationService(AppDbContext appDbContext)
    {
        return new HistoryRelationService(
            new HistoryRelationRepository(appDbContext)
            );
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
