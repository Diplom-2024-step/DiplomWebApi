using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.TransportationTypes;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.TransportationTypes;

public class TransportationTypeService(ITransportationTypeRepository repository, IMapper mapper) :
    CrudService<GetTransportationTypeDto, CreateTransportationTypeDto, UpdateTransportationTypeDto, TransportationType, GetTransportationTypeDto, ITransportationTypeRepository>(repository, mapper),
    ICrudService<GetTransportationTypeDto, CreateTransportationTypeDto, UpdateTransportationTypeDto, TransportationType, GetTransportationTypeDto>, ITransportationTypeService;
