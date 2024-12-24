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

public class OrderActivityRelationRepositoryTest : SharedRelationRepositoryTest<
    OrderActivity, Order, Activity,
    IOrderActivityRelationRepository, IOrderRepository, IActivityRepository
    >
{
    public override Order GetFirstModel()
    {
        return SharedOrderModels.GetSample();
    }

    public override IOrderRepository GetFirstRepository(AppDbContext appDbContext)
    {
        return new OrderRepository(appDbContext);
    }

    public override OrderActivity GetRelationModel(Guid firstId, Guid secondId)
    {
        return new OrderActivity()
        {
            FirstId = firstId,
            SecondId = secondId
        };
    }

    public override IOrderActivityRelationRepository GetRelationRepository(AppDbContext appDbContext)
    {
        return new OrderActivityRelationRepository(appDbContext);
    }

    public override Activity GetSecondModel()
    {
        return SharedActivityModels.GetSample();
    }

    public override IActivityRepository GetSecondRepository(AppDbContext appDbContext)
    {
        return new ActivityRepository(appDbContext);   
    }
}