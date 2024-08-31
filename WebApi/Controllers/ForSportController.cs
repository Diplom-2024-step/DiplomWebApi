using AnytourApi.Application.Services.Models.ForSports;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ForSports;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers;

public class ForSportController(IForSportService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetForSportDto,
    UpdateForSportDto,
    CreateForSportDto,
    IForSportService,
    ForSport,
    GetForSportDto>(CrudService, HttpContextAccessor);
