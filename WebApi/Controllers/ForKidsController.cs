using AnytourApi.Application.Services.Models.ForKids;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ForKids;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers;

public class ForKidsController(IForKidsService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetForKidsDto,
    UpdateForKidsDto,
    CreateForKidsDto,
    IForKidsService,
    ForKid,
    GetForKidsDto>(CrudService, HttpContextAccessor);
