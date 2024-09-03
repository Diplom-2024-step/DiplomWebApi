using AnytourApi.Application.Services.Models.TransportationTypes;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.TransportationTypes;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers;

public class TransportationTypeController(ITransportationTypeService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetTransportationTypeDto,
    UpdateTransportationTypeDto,
    CreateTransportationTypeDto,
    ITransportationTypeService,
    TransportationType,
    GetTransportationTypeDto>(CrudService, HttpContextAccessor);
