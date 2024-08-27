using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Countries;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AnytourApi.Application.Services.Models.Countries;

public class CountryService(ICountryRepository countryRepository, IMapper mapper) :
    CrudService<GetCountryDto, CreateCountryDto, UpdateCountryDto, Country, GetCountryDto, ICountryRepository>(countryRepository,mapper),
    ICrudService<GetCountryDto, CreateCountryDto, UpdateCountryDto, Country, GetCountryDto>, ICountryService;
