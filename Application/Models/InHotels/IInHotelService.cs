using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.InHotels;

namespace AnytourApi.Application.Services.Models.InHotels;

public interface IInHotelService : ICrudService<GetInHotelDto, CreateInHotelDto, UpdateInHotelDto, InHotel, GetInHotelDto>;

