using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Tours;

namespace AnytourApi.Application.Services.Models.Tours;

public interface ITourService : ICrudService<GetTourDto, CreateTourDto, UpdateTourDto, Tour, GetTourDto>;
