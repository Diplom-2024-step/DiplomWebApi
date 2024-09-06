using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.RoomTypes;

namespace AnytourApi.Application.Services.Models.RoomTypes;

public interface IRoomTypeService : ICrudService<GetRoomTypeDto, CreateRoomTypeDto, UpdateRoomTypeDto, RoomType, GetRoomTypeDto>;
