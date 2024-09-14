using AnytourApi.Application.Services.Models.DietTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.DietTypes;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers;

public class DietTypeController(IDietTypeService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetDietTypeDto,
    UpdateDietTypeDto,
    CreateDietTypeDto,
    IDietTypeService,
    DietType,
    GetDietTypeDto>(CrudService, HttpContextAccessor);
