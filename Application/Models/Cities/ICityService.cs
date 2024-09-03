using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Cities;

namespace AnytourApi.Application.Services.Models.Cities;

public interface ICityService : ICrudService<GetCityDto, CreateCityDto, UpdateCityDto,  City, GetCityDto>;
