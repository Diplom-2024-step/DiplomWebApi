using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.CrudRepositories.OrderStatuses;

public class OrderStatusRepositoryTest : SharedRepositoryTest<OrderStatus, IOrderStatusRepository>
{
    protected override IOrderStatusRepository GetRepository(AppDbContext appDbContext)
    {
        return new OrderStatusRepository(appDbContext);
    }

    protected override OrderStatus GetSample()
    {
        return SharedOrderStatusModels.GetSample();
    }

    protected override OrderStatus GetSampleForUpdate()
    {
        return SharedOrderStatusModels.GetSampleForUpdate();
    }
}

