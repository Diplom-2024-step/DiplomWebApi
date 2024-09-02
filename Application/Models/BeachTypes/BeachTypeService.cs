using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.BeachTypes;
using AutoMapper;


namespace AnytourApi.Application.Services.Models.BeachTypes;

public class BeachTypeService(IBeachTypeRepository repository, IMapper mapper) : 
    CrudService<GetBeachTypeDto, CreateBeachTypeDto, UpdateBeachTypeDto, BeachType, GetBeachTypeDto, IBeachTypeRepository>(repository, mapper),
    ICrudService<GetBeachTypeDto, CreateBeachTypeDto, UpdateBeachTypeDto, BeachType, GetBeachTypeDto>, IBeachTypeService;
