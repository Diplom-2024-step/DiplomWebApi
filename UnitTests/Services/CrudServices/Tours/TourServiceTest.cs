using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Tours;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Tours;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.Tours;

public class TourServiceTest : SharedServiceTest<
    GetTourDto,
    CreateTourDto,
    UpdateTourDto,
    Tour,
    GetTourDto,
    ITourRepository,
    ITourService>
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(GetDatabaseContext());

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton<ITourRepository, TourRepository>();

        alternativeServices.AddSingleton<IHotelRepository, HotelRepository>();

        alternativeServices.AddSingleton<ICityRepository, CityRepository>();

        alternativeServices.AddSingleton<ITransportationTypeRepository, TransportationTypeRepository>();

        alternativeServices.AddSingleton<IRoomTypeRepository, RoomTypeRepository>();

        alternativeServices.AddSingleton<IDietTypeRepository, DietTypeRepository>();

        return alternativeServices;
    }

    protected override CreateTourDto GetCreateDtoSample()
    {
        return SharedTourModels.GetSampleCreateDto();
    }

    protected override UpdateTourDto GetUpdateDtoSample()
    {
        return SharedTourModels.GetSampleUpdateDto();
    }

    protected override ITourService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new TourService(builder.GetRequiredService<ITourRepository>(),
            builder.GetRequiredService<ICityRepository>(),
            builder.GetRequiredService<ITransportationTypeRepository>(),
            builder.GetRequiredService<IRoomTypeRepository>(),
            builder.GetRequiredService<IDietTypeRepository>(),
            builder.GetRequiredService<IHotelRepository>(),
            Mapper);

    }
}
