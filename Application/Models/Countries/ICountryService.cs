using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Countries;

namespace AnytourApi.Application.Services.Models.Countries;

public interface ICountryService : ICrudService<GetCountryDto, CreateCountryDto, UpdateCountryDto, Country, GetCountryDto>;
