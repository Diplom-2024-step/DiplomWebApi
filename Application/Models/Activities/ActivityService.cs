using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Activities;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.Activities;

public class ActivityService(IActivityRepository repository, IMapper mapper) :
    CrudService<GetActivityDto, CreateActivityDto, UpdateActivityDto, Activity, GetActivityDto, IActivityRepository>(repository, mapper),
    IActivityService;
