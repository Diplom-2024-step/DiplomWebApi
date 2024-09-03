using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.RoomTypes;
using AutoMapper;


namespace AnytourApi.Application.Services.Models.RoomTypes;

public class RoomTypeService(IRoomTypeRepository repository, IMapper mapper) :
    CrudService<GetRoomTypeDto, CreateRoomTypeDto, UpdateRoomTypeDto, RoomType, GetRoomTypeDto, IRoomTypeRepository>(repository, mapper),
    IRoomTypeService;
