using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.CrudRepositories.ProcessedOrders;

public class ProcessedOrderRepositoryTest : SharedRepositoryTest<ProcessedOrder, IProcessedOrderRepository>
{
    protected override IProcessedOrderRepository GetRepository(AppDbContext appDbContext)
    {
        return new ProcessedOrderRepository(appDbContext);
    }

    protected override ProcessedOrder GetSample()
    {
        return SharedProcessedOrderModels.GetSample();
    }

    protected override ProcessedOrder GetSampleForUpdate()
    {
        return SharedProcessedOrderModels.GetSampleForUpdate();
    }
}
