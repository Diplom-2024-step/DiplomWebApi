using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ForSports;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AnytourApi.Application.Services.Models.ForSports;

public class ForSportService(IForSportRepository forSportsRepository, IMapper mapper) :
    CrudService<GetForSportDto, CreateForSportDto, UpdateForSportDto, ForSport, GetForSportDto, IForSportRepository>(forSportsRepository,mapper),
     IForSportService;
