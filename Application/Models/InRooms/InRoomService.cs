using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.InRooms;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.InRooms;

public class InRoomService(IInRoomRepository repository, IMapper mapper) : 
    CrudService<GetInRoomDto, CreateInRoomDto, UpdateInRoomDto, InRoom, GetInRoomDto, IInRoomRepository>(repository, mapper),
    IInRoomService;
