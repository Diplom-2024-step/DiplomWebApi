using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.DietTypes;
using AutoMapper;


namespace AnytourApi.Application.Services.Models.DietTypes;

public class DietTypeService(IDietTypeRepository repository, IMapper mapper) : 
    CrudService<GetDietTypeDto, CreateDietTypeDto, UpdateDietTypeDto, DietType, GetDietTypeDto, IDietTypeRepository>(repository, mapper),
    IDietTypeService;
