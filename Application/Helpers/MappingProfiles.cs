using AnytourApi.Application.Repositories.Shared;
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
using AnytourApi.Dtos.Dto.Models.Photos;
using AnytourApi.Dtos.Dto.Models.Activities;
using AnytourApi.Dtos.Dto.Models.Reviews;
using AnytourApi.Dtos.Dto.Models.OrderStatuses;
using AnytourApi.Dtos.Dto.Models.DietTypes;
using AnytourApi.Dtos.Dto.Models.Tours;

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

        CreateMap<UpdateHotelDto, Hotel>().ForMember(e => e.InHotels, op => op.Ignore());
        CreateMap<CreateHotelDto, Hotel>().ForMember(e => e.InHotels, op => op.Ignore());

        CreateMap<UpdateHotelDto, Hotel>().ForMember(e => e.ForSports, op => op.Ignore());
        CreateMap<CreateHotelDto, Hotel>().ForMember(e => e.ForSports, op => op.Ignore());

        CreateMap<UpdateHotelDto, Hotel>().ForMember(e => e.BeachTypes, op => op.Ignore());
        CreateMap<CreateHotelDto, Hotel>().ForMember(e => e.BeachTypes, op => op.Ignore());

        CreateMap<UpdateHotelDto, Hotel>().ForMember(e => e.RoomTypes, op => op.Ignore());
        CreateMap<CreateHotelDto, Hotel>().ForMember(e => e.RoomTypes, op => op.Ignore());

        //Tours
        CreateMap<Tour, GetTourDto>();

        CreateMap<UpdateTourDto, Tour>();
        CreateMap<CreateTourDto, Tour>();

        CreateMap<UpdateTourDto, Tour>().ForMember(e => e.Users, op => op.Ignore());
        CreateMap<CreateTourDto, Tour>().ForMember(e => e.Users, op => op.Ignore());

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

        //Photo
        CreateMap<Photo, GetPhotoDto>();

        CreateMap<UpdatePhotoDto, Photo>();

        CreateMap<CreatePhotoDto, Photo>();

        //Review
        CreateMap<Review, GetReviewDto>();

        CreateMap<UpdateReviewDto, Review>();

        CreateMap<CreateReviewDto, Review>();


        //Activity
        CreateMap<Activity, GetActivityDto>()
    .ForMember(e => e.Urls, op => op.MapFrom(e => e.Photos.Select(p => p.Id.ToString()).ToList()));

        CreateMap<UpdateActivityDto, Activity>();

        CreateMap<CreateActivityDto, Activity>();

        // OrderStatus
        CreateMap<OrderStatus, GetOrderStatusDto>();

        CreateMap<UpdateOrderStatusDto, OrderStatus>();

        CreateMap<CreateOrderStatusDto, OrderStatus>();

        //DietType
        CreateMap<DietType, GetDietTypeDto>();

        CreateMap<UpdateDietTypeDto, DietType>();

        CreateMap<CreateDietTypeDto, DietType>();
    }
}
