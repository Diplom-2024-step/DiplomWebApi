using AnytourApi.Application.Services.Models.RoomTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.RoomTypes;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers;

public class RoomTypeController(IRoomTypeService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetRoomTypeDto,
    UpdateRoomTypeDto,
    CreateRoomTypeDto,
    IRoomTypeService,
    RoomType,
    GetRoomTypeDto>(CrudService, HttpContextAccessor);
