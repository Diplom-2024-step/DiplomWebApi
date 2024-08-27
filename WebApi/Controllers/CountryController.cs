using AnytourApi.Application.Services.Models.Countries;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Countries;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers;

public class CountryController(ICountryService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetCountryDto,
    UpdateCountryDto,
    CreateCountryDto,
    ICountryService,
    Country,
    GetCountryDto>(CrudService, HttpContextAccessor);
