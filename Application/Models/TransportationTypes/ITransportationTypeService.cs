using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.TransportationTypes;

namespace AnytourApi.Application.Services.Models.TransportationTypes;

public interface ITransportationTypeService : ICrudService<GetTransportationTypeDto, CreateTransportationTypeDto, UpdateTransportationTypeDto, TransportationType, GetTransportationTypeDto>;

