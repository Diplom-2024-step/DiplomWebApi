﻿using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Tours;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.Tours;

public class TourService(ITourRepository toursRepository, ICityRepository cityRepository,
    ITransportationTypeRepository transportationTypeRepository, IRoomTypeRepository roomTypeRepository,
    IDietTypeRepository dietTypeRepository, IHotelRepository hotelRepository, IMapper mapper) : 
    CrudService<GetTourDto, CreateTourDto, UpdateTourDto, Tour, GetTourDto, ITourRepository>(toursRepository, mapper),
    ITourService
{
    public override async Task<Guid> CreateAsync(CreateTourDto createDto, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<Tour>(createDto);

        model.Hotel = await hotelRepository.GetAsync(createDto.HotelId, cancellationToken);
        model.FromCity = await cityRepository.GetAsync(createDto.FromCityId, cancellationToken);
        model.ToCity = await cityRepository.GetAsync(createDto.ToCityId, cancellationToken);
        model.TransportationType = await transportationTypeRepository.GetAsync(createDto.TransportationTypeId, cancellationToken);
        model.RoomType = await roomTypeRepository.GetAsync(createDto.RoomTypeId, cancellationToken);
        model.DietType = await dietTypeRepository.GetAsync(createDto.DietTypeId, cancellationToken);

        return await Repository.AddAsync(model, cancellationToken);
    }
}
