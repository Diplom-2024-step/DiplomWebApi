using AnytourApi.Application.Services.Models.Tours;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Tours;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers.Tours;

public class TourController(ITourService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetTourDto,
    UpdateTourDto,
    CreateTourDto,
    ITourService,
    Tour,
    GetTourDto>(CrudService, HttpContextAccessor);
