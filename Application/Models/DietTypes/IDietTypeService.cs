using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.DietTypes;

namespace AnytourApi.Application.Services.Models.DietTypes;

public interface IDietTypeService : ICrudService<GetDietTypeDto, CreateDietTypeDto, UpdateDietTypeDto, DietType, GetDietTypeDto>;
