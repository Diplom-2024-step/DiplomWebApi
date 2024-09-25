using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Tours;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Tours;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Shared;
using Faker;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models;

public class SharedTourModels : SharedModelsBase, IShareModels<CreateTourDto, UpdateTourDto, Tour>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        SharedReviewablePhotoableModels.AddAllDependencies(services);
        SharedCityModels.AddAllDependencies(services);
        SharedHotelModels.AddAllDependencies(services);
        SharedTransportationTypeModels.AddAllDependencies(services);
        SharedRoomTypeModels.AddAllDependencies(services);
        SharedDietTypeModels.AddAllDependencies(services);
        SharedUserModels.AddAllDependencies(services);

        services.AddScoped<ITourRepository, TourRepository>();

        services.AddScoped<ITourService, TourService>();
    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var tourDto = SharedTourModels.GetSampleCreateDto();

        tourDto.HotelId = await SharedHotelModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        tourDto.FromCityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        tourDto.ToCityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        tourDto.TransportationTypeId = await SharedTransportationTypeModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        tourDto.RoomTypeId = await SharedRoomTypeModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        tourDto.DietTypeId = await SharedDietTypeModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
       
        
        return await serviceProvider.GetService<ITourService>().CreateAsync(tourDto, cancellationToken);
    }

    public static Tour GetSample()
    {
        return new Tour()
        {
            Name = Lorem.Sentence(),
            Hotel = SharedHotelModels.GetSample(),
            StartDate = DateTime.Now.ToUniversalTime(),
            EndDate = DateTime.Now.AddDays(15).ToUniversalTime(),
            FromCity = SharedCityModels.GetSample(),
            ToCity = SharedCityModels.GetSample(),
            PriceUSD = 1000,
            Description = "Description",
            Duration = 15,
            TransportationType = SharedTransportationTypeModels.GetSample(),
            DietType = SharedDietTypeModels.GetSample(),
            RoomType = SharedRoomTypeModels.GetSample(),
            HowManyAdults = 2,
            HowManyKids = 2,
            Photos = [SharedPhotoModels.GetSample()],
            Reviews = [SharedReviewModels.GetSample()],
        };
    }

    public static CreateTourDto GetSampleCreateDto()
    {
        return new CreateTourDto()
        {
            Name = Lorem.Sentence(),
            HotelId = Guid.NewGuid(),
            SartDate = DateTime.Now.ToUniversalTime(),
            EndDate = DateTime.Now.AddDays(15).ToUniversalTime(),
            FromCityId = Guid.NewGuid(),
            ToCityId = Guid.NewGuid(),
            PriceUSD = 1000,
            Description = "Description",
            Duration = 15,
            TransportationTypeId = Guid.NewGuid(),           
            DietTypeId = Guid.NewGuid(),
            RoomTypeId = Guid.NewGuid(),
            HowManyAdults = 2,
            HowManyKids = 2,
            UserIds = [Guid.NewGuid()],
        };
    }

    public static Tour GetSampleForUpdate()
    {
        return new Tour()
        {
            Name = Lorem.GetFirstWord() + "12",
            Hotel = SharedHotelModels.GetSampleForUpdate(),
            StartDate = DateTime.Now.ToUniversalTime(),
            EndDate = DateTime.Now.AddDays(15).ToUniversalTime(),
            FromCity = SharedCityModels.GetSampleForUpdate(),
            ToCity = SharedCityModels.GetSampleForUpdate(),
            PriceUSD = 1500,
            Description = "Description5",
            Duration = 20,
            TransportationType = SharedTransportationTypeModels.GetSampleForUpdate(),
            DietType = SharedDietTypeModels.GetSampleForUpdate(),
            RoomType = SharedRoomTypeModels.GetSampleForUpdate(),            
            HowManyAdults = 3,
            HowManyKids = 4,
            Photos = [SharedPhotoModels.GetSampleForUpdate()],
            Reviews = [SharedReviewModels.GetSampleForUpdate()],
        };
    }

    public static UpdateTourDto GetSampleUpdateDto()
    {
        return new UpdateTourDto()
        {
            Name = Lorem.GetFirstWord(),
            HotelId = Guid.NewGuid(),
            SartDate = DateTime.Now.ToUniversalTime(),
            EndDate = DateTime.Now.AddDays(15).ToUniversalTime(),
            FromCityId = Guid.NewGuid(),
            ToCityId = Guid.NewGuid(),
            PriceUSD = 1500,
            Description = "Description5",
            Duration = 20,
            TransportationTypeId = Guid.NewGuid(),
            DietTypeId = Guid.NewGuid(),
            RoomTypeId = Guid.NewGuid(),          
            HowManyAdults = 3,
            HowManyKids = 4,
            UserIds = [Guid.NewGuid()],
        };
    }
}
