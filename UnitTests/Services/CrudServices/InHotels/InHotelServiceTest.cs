using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.InHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.InHotels;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.InHotels;

public class InHotelServiceTest : SharedServiceTest<
    GetInHotelDto,
    CreateInHotelDto,
    UpdateInHotelDto,
    InHotel,
    GetInHotelDto,
    IInHotelRepository,
    IInHotelService
    >
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(GetDatabaseContext());

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton<IInHotelRepository, InHotelRepository>();


        return alternativeServices;
    }

    protected override CreateInHotelDto GetCreateDtoSample()
    {
        return SharedInHotelModels.GetSampleCreateDto();
    }

    protected override UpdateInHotelDto GetUpdateDtoSample()
    {
        return SharedInHotelModels.GetSampleUpdateDto();
    }

    protected override IInHotelService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new InHotelService(builder.GetRequiredService<IInHotelRepository>(), Mapper);
    }
}
