﻿using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Users;
using AnytourApi.Application.Services.Models.Photos;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Activities;
using AnytourApi.Dtos.Dto.Models.Tours;
using AnytourApi.Dtos.Shared;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.Tours;

public class TourService(ITourRepository toursRepository, ICityRepository cityRepository,
    ITransportationTypeRepository transportationTypeRepository, IRoomTypeRepository roomTypeRepository,
    IDietTypeRepository dietTypeRepository, IHotelRepository hotelRepository,
    IPhotoService photoService, IActivityRepository activityRepository, IMapper mapper) : 
    CrudService<GetTourDto, CreateTourDto, UpdateTourDto, Tour, GetTourDto, ITourRepository>(toursRepository, mapper),
    ITourService
{
    public override async Task<ReturnPageDto<GetTourDto>> GetAllAsync(FilterPaginationDto dto, CancellationToken cancellationToken)
    {
        var result = await base.GetAllAsync(dto, cancellationToken);


        foreach (var item in result.Models)
        {
            var photosTour = await photoService.GetAllPhotosForPhotoableId(item.Id, cancellationToken);

            var photosHotel = await photoService.GetAllPhotosForPhotoableId(item.Hotel.Id, cancellationToken);

            foreach (var activity in item.Activities)
            {
                var photosActivitiesIds = await photoService.GetAllPhotosForPhotoableId(activity.Id, cancellationToken);

                List<string> activitiesIds = new List<string>();
                foreach (var photo in photosActivitiesIds)
                {
                    activitiesIds.Add(photo.Id.ToString());
                }

                activity.Urls = activitiesIds;
            }

            List<string> ids = new List<string>();

            List<string> hotelIds = new List<string>();

            foreach (var photo in photosTour)
            {
                ids.Add(photo.Id.ToString());
            }

            foreach (var photo in photosHotel)
            {
                ids.Add(photo.Id.ToString());
                hotelIds.Add(photo.Id.ToString());
            }

            item.Urls = ids;
            item.Hotel.Urls = hotelIds;
        }

        return result;
    }


    public override async Task<GetTourDto?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var res = await base.GetAsync(id, cancellationToken);

        if (res == null)
        {
            return res;
        }

        var photosTour = await photoService.GetAllPhotosForPhotoableId(res.Id, cancellationToken);

        var photosHotel = await photoService.GetAllPhotosForPhotoableId(res.Hotel.Id, cancellationToken);

        List<string> ids = new List<string>();

        List<string> hotelIds = new List<string>();

        foreach (var photo in photosTour)
        {
            ids.Add(photo.Id.ToString());
        }

        foreach (var photo in photosHotel)
        {
            ids.Add(photo.Id.ToString());
            hotelIds.Add(photo.Id.ToString());
        }


        res.Urls = ids;
        res.Hotel.Urls= hotelIds;

        return res;
    }


    public override async Task<Guid> CreateAsync(CreateTourDto createDto, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<Tour>(createDto);

        model.Hotel = await hotelRepository.GetAsync(createDto.HotelId, cancellationToken);
        model.FromCity = await cityRepository.GetAsync(createDto.FromCityId, cancellationToken);
        model.ToCity = await cityRepository.GetAsync(createDto.ToCityId, cancellationToken);
        model.TransportationType = await transportationTypeRepository.GetAsync(createDto.TransportationTypeId, cancellationToken);
        model.RoomType = await roomTypeRepository.GetAsync(createDto.RoomTypeId, cancellationToken);
        model.DietType = await dietTypeRepository.GetAsync(createDto.DietTypeId, cancellationToken);
        model.Activities = await activityRepository.GetAllModelsByIdsAsync(createDto.ActivityIds, cancellationToken);

        return await Repository.AddAsync(model, cancellationToken);
    }

    public override async Task UpdateAsync(UpdateTourDto updateDto, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<Tour>(updateDto);

        model.Hotel = await hotelRepository.GetAsync(updateDto.HotelId, cancellationToken);
        model.FromCity = await cityRepository.GetAsync(updateDto.FromCityId, cancellationToken);
        model.ToCity = await cityRepository.GetAsync(updateDto.ToCityId, cancellationToken);
        model.TransportationType = await transportationTypeRepository.GetAsync(updateDto.TransportationTypeId, cancellationToken);
        model.RoomType = await roomTypeRepository.GetAsync(updateDto.RoomTypeId, cancellationToken);
        model.DietType = await dietTypeRepository.GetAsync(updateDto.DietTypeId, cancellationToken);
        model.Activities = await activityRepository.GetAllModelsByIdsAsync(updateDto.ActivityIds, cancellationToken);

        await Repository.UpdateAsync(model, cancellationToken);
    }

}
