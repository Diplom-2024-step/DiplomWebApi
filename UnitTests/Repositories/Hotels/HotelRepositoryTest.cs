using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.Hotels;

public class HotelRepositoryTest : SharedRepositoryTest<Hotel, IHotelRepository>
{
    protected override IHotelRepository GetRepository(AppDbContext appDbContext)
    {
        return new HotelRepository(appDbContext);
    }

    protected override Hotel GetSample()
    {
        return SharedHotelModels.GetSample();
    }

    protected override Hotel GetSampleForUpdate()
    {
        return SharedHotelModels.GetSampleForUpdate();
    }
}
