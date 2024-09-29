using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ForKids;

namespace AnytourApi.Application.Services.Models.ForKids;

public interface IForKidsService : ICrudService<GetForKidDto, CreateForKidDto, UpdateForKidDto, ForKid, GetForKidDto>;