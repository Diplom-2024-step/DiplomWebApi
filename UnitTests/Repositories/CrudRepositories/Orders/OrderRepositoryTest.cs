using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.CrudRepositories.Orders;

public class OrderRepositoryTest : SharedRepositoryTest<Order, IOrderRepository>
{
    protected override IOrderRepository GetRepository(AppDbContext appDbContext)
    {
        return new OrderRepository(appDbContext);
    }

    protected override Order GetSample()
    {
        return SharedOrderModels.GetSample();
    }

    protected override Order GetSampleForUpdate()
    {
        return SharedOrderModels.GetSampleForUpdate();
    }
}
