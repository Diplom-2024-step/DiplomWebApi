using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ForKids;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.ForKids;

public class ForKidsService(IForKidsRepository repository, IMapper mapper)
    : CrudService<GetForKidDto, CreateForKidDto, UpdateForKidDto, ForKid, GetForKidDto, IForKidsRepository>(repository, mapper),
    IForKidsService;
