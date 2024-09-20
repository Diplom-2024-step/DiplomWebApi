using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.InRooms;

namespace AnytourApi.Application.Services.Models.InRooms;

public interface IInRoomService : ICrudService<GetInRoomDto, CreateInRoomDto, UpdateInRoomDto, InRoom, GetInRoomDto>;

