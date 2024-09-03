using AnytourApi.Application.Services.Models.BeachTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.BeachTypes;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers;

public class BeachTypeController(IBeachTypeService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetBeachTypeDto,
    UpdateBeachTypeDto,
    CreateBeachTypeDto,
    IBeachTypeService,
    BeachType,
    GetBeachTypeDto>(CrudService, HttpContextAccessor);
