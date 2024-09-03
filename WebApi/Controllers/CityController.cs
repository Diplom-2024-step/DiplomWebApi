using AnytourApi.Application.Services.Models.Cities;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Cities;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers;

public class CityController(ICityService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetCityDto,
    UpdateCityDto,
    CreateCityDto,
    ICityService,
    City,
    GetCityDto>(CrudService, HttpContextAccessor);