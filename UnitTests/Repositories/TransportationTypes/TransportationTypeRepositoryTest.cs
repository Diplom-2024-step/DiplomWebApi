using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.TransportationTypes;

public class TransportationTypeRepositoryTest : SharedRepositoryTest<TransportationType, ITransportationTypeRepository>
{
    protected override ITransportationTypeRepository GetRepository(AppDbContext appDbContext)
    {
        return new TransportationTypeRepository(appDbContext);
    }

    protected override TransportationType GetSample()
    {
        return SharedTransportationTypeModels.GetSample();
    }

    protected override TransportationType GetSampleForUpdate()
    {
        return SharedTransportationTypeModels.GetSampleForUpdate();
    }
}
