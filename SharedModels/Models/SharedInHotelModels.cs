using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.ForSports;
using AnytourApi.Application.Services.Models.InHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Countries;
using AnytourApi.Dtos.Dto.Models.InHotels;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AnytourApi.SharedModels.Models;

public class SharedInHotelModels : SharedModelsBase, IShareModels<CreateInHotelDto, UpdateInHotelDto, InHotel>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<IInHotelRepository, InHotelRepository>();
        
        services.AddScoped<IInHotelService, InHotelService>();
    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var inHotelDto = SharedInHotelModels.GetSampleCreateDto();

        return await serviceProvider.GetService<IInHotelService>().CreateAsync(inHotelDto, cancellationToken);
    }
    public static InHotel GetSample()
    {
        return new InHotel()
        {
            Name = "HotelName"
        };
    }

    public static CreateInHotelDto GetSampleCreateDto()
    {
        return new CreateInHotelDto()
        {
            Name = "test",
        };
    }

    public static InHotel GetSampleForUpdate()
    {
        return new InHotel()
        {
            Name = "Name123",

        };
    }

    public static UpdateInHotelDto GetSampleUpdateDto()
    {
        return new UpdateInHotelDto()
        {
            Name = "test12",
        };
    }
}
