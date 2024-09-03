using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Hotels;

namespace AnytourApi.Application.Services.Models.Hotels;

public interface IHotelService : ICrudService<GetHotelDto, CreateHotelDto, UpdateHotelDto, Hotel, GetHotelDto>;
