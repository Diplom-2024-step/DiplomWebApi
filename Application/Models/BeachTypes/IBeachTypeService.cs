using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.BeachTypes;

namespace AnytourApi.Application.Services.Models.BeachTypes;

public interface IBeachTypeService : ICrudService<GetBeachTypeDto, CreateBeachTypeDto, UpdateBeachTypeDto, BeachType, GetBeachTypeDto>;
