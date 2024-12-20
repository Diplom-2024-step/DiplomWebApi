﻿using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Countries;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Cities;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.Cities;

public class CityService(ICityRepository cityRepository, ICountryRepository countryRepository, IMapper mapper) :
    CrudService<GetCityDto, CreateCityDto, UpdateCityDto, City, GetCityDto, ICityRepository>(cityRepository, mapper),
    ICityService
{
    public override async Task<Guid> CreateAsync(CreateCityDto createDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<City>(createDto);

        model.Country = await countryRepository.GetAsync(createDto.CountryId, cancellationToken);

        return await Repository.AddAsync(model, cancellationToken);
    }

    public override async Task UpdateAsync(UpdateCityDto updateCityDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<City>(updateCityDto);

        model.Country = await countryRepository.GetAsync(updateCityDto.CountryId, cancellationToken);

        await Repository.UpdateAsync(model, cancellationToken);
    }

}
