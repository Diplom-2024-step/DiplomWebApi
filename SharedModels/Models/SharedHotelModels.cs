using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Hotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Hotels;
using AnytourApi.EfPersistence.Repositories.Models;
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

        services.AddScoped<IHotelRepository, HotelRepository>();

        services.AddScoped<IHotelService, HotelService>();
    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var hotelDto = SharedHotelModels.GetSampleCreateDto();

        hotelDto.CityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);

        hotelDto.InHotelIds = [await SharedInHotelModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken)];

        return await serviceProvider.GetService<IHotelService>().CreateAsync(hotelDto, cancellationToken);

    }

    public static Hotel GetSample()
    {
        return new Hotel()
        {
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
            Longitud= 12.3,
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
            InHotelIds = [Guid.NewGuid()]
            
            
        };
    }

    public static Hotel GetSampleForUpdate()
    {
        return new Hotel()
        {
            Adress = "test12",
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
            InHotelIds = [Guid.NewGuid()]
        };
            }
}
