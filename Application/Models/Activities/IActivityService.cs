using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Activities;

namespace AnytourApi.Application.Services.Models.Activities;

public interface IActivityService : ICrudService<GetActivityDto, CreateActivityDto, UpdateActivityDto, Activity, GetActivityDto>;
