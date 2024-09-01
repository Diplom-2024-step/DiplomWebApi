using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ForSports;

namespace AnytourApi.Application.Services.Models.ForSports;

public interface IForSportService : ICrudService<GetForSportDto, CreateForSportDto, UpdateForSportDto, ForSport, GetForSportDto>;

