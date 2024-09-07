﻿using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Domain.ForFilter;
using AnytourApi.Domain.ForSort;
using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Cities;
using AnytourApi.Dtos.Dto.Models.BeachTypes;
using AnytourApi.Dtos.Dto.Models.Countries;
using AnytourApi.Dtos.Dto.Models.ForSports;
using AnytourApi.Dtos.Dto.Models.InHotels;
using AnytourApi.Dtos.Dto.Models.TransportationTypes;
using AnytourApi.Dtos.Dto.Users;
using AnytourApi.Dtos.Shared;
using AutoMapper;
using AnytourApi.Dtos.Dto.Models.RoomTypes;
using AnytourApi.Dtos.Dto.Models.Hotels;
using AnytourApi.Dtos.Dto.Models.Activities;

namespace AnytourApi.Application.Services.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //Shared
        CreateMap<FilterPaginationDto, FilterPagination>().ForMember(
            c => c.Filters,
            op => op.MapFrom(v => v.Filters)).ForMember(
            c => c.Sorts,
            op => op.MapFrom(v => v.Sorts));

        CreateMap<FilterDto, Filter>();

        CreateMap<SortDto, Sort>();

        CreateMap(typeof(PaginatedCollection<>), typeof(ReturnPageDto<>));

        //User
        CreateMap<User, GetUserDto>();

        CreateMap<User, UpdateUserDto>();

        CreateMap<UpdateUserDto, User>();

        CreateMap<UserRegistrationDto, User>()
            .ForMember(e => e.PasswordHash, op => op.MapFrom(e => e.Password));

        CreateMap<GetUserDto, User>();

        //Country
        CreateMap<Country, GetCountryDto>();

        CreateMap<UpdateCountryDto, Country>();

        CreateMap<CreateCountryDto, Country>();

        //ForSport
        CreateMap<ForSport, GetForSportDto>();

        CreateMap<UpdateForSportDto, ForSport>();

        CreateMap<CreateForSportDto, ForSport>();

        //InHotel
        CreateMap<InHotel, GetInHotelDto>();

        CreateMap<UpdateInHotelDto, InHotel>();

        CreateMap<CreateInHotelDto, InHotel>();


        //City
        CreateMap<City, GetCityDto>();

        CreateMap<UpdateCityDto, City>();

        CreateMap<CreateCityDto, City>();

        //Hotels
        CreateMap<Hotel, GetHotelDto>();

        CreateMap<UpdateHotelDto, Hotel>();

        CreateMap<CreateHotelDto, Hotel>();


        //TransportationType
        CreateMap<TransportationType, GetTransportationTypeDto>();

        CreateMap<UpdateTransportationTypeDto, TransportationType>();

        CreateMap<CreateTransportationTypeDto, TransportationType>();

        //BeachType
        CreateMap<BeachType, GetBeachTypeDto>();

        CreateMap<UpdateBeachTypeDto, BeachType>();

        CreateMap<CreateBeachTypeDto, BeachType>();

        //RoomType
        CreateMap<RoomType, GetRoomTypeDto>();

        CreateMap<UpdateRoomTypeDto, RoomType>();

        CreateMap<CreateRoomTypeDto, RoomType>();

        //Activity
        CreateMap<Activity, GetActivityDto>();

        CreateMap<UpdateActivityDto, Activity>();

        CreateMap<CreateActivityDto, Activity>();
    }
}
