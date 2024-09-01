
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.InHotels;

public class InHotelRepositoryTest : SharedRepositoryTest<InHotel, IInHotelRepository>
{
    protected override IInHotelRepository GetRepository(AppDbContext appDbContext)
    {
        return new InHotelRepository(appDbContext);
    }

    protected override InHotel GetSample()
    {
        return SharedInHotelModels.GetSample();
    }

    protected override InHotel GetSampleForUpdate()
    {
        return SharedInHotelModels.GetSampleForUpdate();
    }
}
