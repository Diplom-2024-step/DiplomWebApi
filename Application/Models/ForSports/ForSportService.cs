using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ForSports;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AnytourApi.Application.Services.Models.ForSports;

public class ForSportService(IForSportsRepository forSportsRepository, IMapper mapper) :
    CrudService<GetForSportDto, CreateForSportDto, UpdateForSportDto, ForSport, GetForSportDto, IForSportsRepository>(forSportsRepository,mapper),
    ICrudService<GetForSportDto, CreateForSportDto, UpdateForSportDto, ForSport, GetForSportDto>, IForSportService;
