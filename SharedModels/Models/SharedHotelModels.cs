using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Hotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Hotels;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.Infrastructure.LinkFactories;
using AnytourApi.SharedModels.Shared;
using Faker;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models;

public class SharedHotelModels : SharedModelsBase, IShareModels<CreateHotelDto, UpdateHotelDto, Hotel>
{
    public static void AddAllDependencies(IServiceCollection services)
    {

        SharedCityModels.AddAllDependencies(services);
        SharedInHotelModels.AddAllDependencies(services);
        SharedForSportModels.AddAllDependencies(services);
        SharedBeachTypeModels.AddAllDependencies(services);
        SharedReviewablePhotoableModels.AddAllDependencies(services);
        SharedForKidsModels.AddAllDependencies(services);
        SharedInRoomModels.AddAllDependencies(services);

        SharedRoomTypeModels.AddAllDependencies(services);

        services.AddScoped<IHotelRepository, HotelRepository>();

        services.AddScoped<IHotelService, HotelService>();

        services.AddScoped<ILinkFactory, LinkFactory>();
    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var hotelDto = SharedHotelModels.GetSampleCreateDto();

        hotelDto.CityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        hotelDto.InHotelIds = [await SharedInHotelModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken)];
        hotelDto.ForSportIds = [await SharedForSportModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken)];
        hotelDto.BeachTypeIds = [await SharedBeachTypeModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken)];
        hotelDto.RoomTypeIds = [await SharedRoomTypeModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken)];
        hotelDto.ForKidIds = [await SharedForKidsModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken)];
        hotelDto.InRoomIds = [await SharedInRoomModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken)];

        return await serviceProvider.GetService<IHotelService>().CreateAsync(hotelDto, cancellationToken);
    }

    public static Hotel GetSample()
    {
        return new Hotel()
        {
            Photos = [SharedPhotoModels.GetSample()],
            Reviews = [SharedReviewModels.GetSample()],
            Adress = "test",
            City = SharedCityModels.GetSample(),
            Description = "Description",
            DescriptionForBeachTypes = "ecas",
            DescriptionForInHotels = "sffa",
            DescriptionForKids = Lorem.Paragraph(),
            DescriptionForSports = Lorem.Paragraph(),
            DescriptionLocation = Lorem.Paragraph(),
            HowManyRooms = 12,
            Latitud = 12.2,
            Longitud = 12.3,
            Name = Lorem.Sentence(),
            Stars = 2,
            TurpravdaId = 12,
            TurpravdaScore = 1
        };
    }

    public static CreateHotelDto GetSampleCreateDto()
    {
        return new CreateHotelDto()
        {
            Adress = "test",
            CityId = Guid.NewGuid(),
            Description = "Description",
            DescriptionForBeachTypes = "ecas",
            DescriptionForInHotels = "sffa",
            DescriptionForKids = Lorem.Paragraph(),
            DescriptionForSports = Lorem.Paragraph(),
            DescriptionLocation = Lorem.Paragraph(),
            HowManyRooms = 12,
            Latitud = 12.2,
            Longitud= 12.3,
            Name = Lorem.Sentence(),
            Stars = 2,
            TurpravdaId = 12,
            TurpravdaScore = 1,
            InHotelIds = [Guid.NewGuid()],
            ForSportIds = [Guid.NewGuid()],
            BeachTypeIds = [Guid.NewGuid()],
            RoomTypeIds = [Guid.NewGuid()],
            ForKidIds = [Guid.NewGuid()],
            InRoomIds = [Guid.NewGuid()]
        };
    }

    public static Hotel GetSampleForUpdate()
    {
        return new Hotel()
        {
            Photos = [SharedPhotoModels.GetSampleForUpdate()],
            Reviews = [SharedReviewModels.GetSampleForUpdate()],
            Adress = "test",
            City = SharedCityModels.GetSampleForUpdate(),
            Description = "Description12",
            DescriptionForBeachTypes = "ecas12",
            DescriptionForInHotels = "sffa12",
            DescriptionForKids = Lorem.Sentence(),
            DescriptionForSports = Lorem.Sentence(),
            DescriptionLocation = Lorem.Sentence(),
            HowManyRooms = 12,
            Latitud = 1.4,
            Longitud= 1.3,
            Name = Lorem.GetFirstWord()+"12",
            Stars = 3,
            TurpravdaId = 2,
            TurpravdaScore = 2
        };
    }

    public static UpdateHotelDto GetSampleUpdateDto()
    {
        return new UpdateHotelDto()
        {
            Adress = "test12",
            CityId = Guid.NewGuid(),
            Description = "Description12",
            DescriptionForBeachTypes = "ecas12",
            DescriptionForInHotels = "sffa12",
            DescriptionForKids = Lorem.Sentence(),
            DescriptionForSports = Lorem.Sentence(),
            DescriptionLocation = Lorem.Sentence(),
            HowManyRooms = 12,
            Latitud = 1.4,
            Longitud= 1.3,
            Name = Lorem.GetFirstWord(),
            Stars = 3,
            TurpravdaId = 2,
            TurpravdaScore = 2,
            InHotelIds = [Guid.NewGuid()],
            ForSportIds = [Guid.NewGuid()],
            BeachTypesIds = [Guid.NewGuid()],
            RoomTypeIds = [Guid.NewGuid()],
            ForKidIds = [Guid.NewGuid()],
            InRoomIds = [Guid.NewGuid()]
        };
    }
}
