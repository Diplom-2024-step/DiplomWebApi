﻿using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Hotels;
using AnytourApi.Application.Services.Models.InHotels;
using AnytourApi.Application.Services.Models.Photos;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Hotels;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.Hotels;

public class HotelServiceTest : SharedServiceTest<
    GetHotelDto,
    CreateHotelDto,
    UpdateHotelDto,
    Hotel,
    GetHotelDto,
    IHotelRepository,
    IHotelService
    >
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(GetDatabaseContext());

        alternativeServices.AddSingleton(Mapper);

        SharedHotelModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }

    protected override CreateHotelDto GetCreateDtoSample()
    {
        return SharedHotelModels.GetSampleCreateDto();
    }

    protected override UpdateHotelDto GetUpdateDtoSample()
    {
        return SharedHotelModels.GetSampleUpdateDto();
    }

    protected override IHotelService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new HotelService(builder.GetRequiredService<IHotelRepository>(),
            builder.GetRequiredService<ICityRepository>(),
            builder.GetRequiredService<IInHotelRepository>(),
            builder.GetRequiredService<IForSportRepository>(),
            builder.GetRequiredService<IBeachTypeRepository>(),
            builder.GetRequiredService<IRoomTypeRepository>(),
            builder.GetRequiredService<IInRoomRepository>(),
            builder.GetRequiredService<IForKidsRepository>(),
            builder.GetRequiredService<IDietTypeRepository>(),
            builder.GetRequiredService<IPhotoService>(),
            Mapper);
    }
}