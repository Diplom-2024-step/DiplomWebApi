using AnytourApi.Application.Services.Models.InRooms;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.InRooms;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers;
public class InRoomController(IInRoomService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetInRoomDto,
    UpdateInRoomDto,
    CreateInRoomDto,
    IInRoomService,
    InRoom,
    GetInRoomDto>(CrudService, HttpContextAccessor);


