using AnytourApi.Application.Services.Models.Activities;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Activities;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers;

public class ActivityController(IActivityService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetActivityDto,
    UpdateActivityDto,
    CreateActivityDto,
    IActivityService,
    Activity,
    GetActivityDto>(CrudService, HttpContextAccessor);
