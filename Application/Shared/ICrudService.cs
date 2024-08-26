using AnytourApi.Domain.Models.Shared;
using AnytourApi.Dtos.Shared;

namespace AnytourApi.Application.Services.Shared;

public interface ICrudService<TGetDto, TCreateDto, TUpdateDto, TModel, TGetLightDto>
    where TModel : class, IModel
    where TGetDto : ModelDto
    where TUpdateDto : ModelDto

{
    Task<Guid> CreateAsync(TCreateDto createDto, CancellationToken cancellationToken);
    Task UpdateAsync(TUpdateDto updateDto, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<TGetDto?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<TModel?> GetRawAsync(Guid id, CancellationToken cancellationToken);
    TGetDto? Get(Guid id);
    TModel? GetRaw(Guid id);
    Task<ReturnPageDto<TGetLightDto>> GetAllAsync(FilterPaginationDto dto, CancellationToken cancellationToken);
    Task<ICollection<TGetDto?>> GetAllModelsByIdsAsync(List<Guid> ids, CancellationToken cancellationToken);
    ICollection<TGetDto?> GetAllModelsByIds(List<Guid> ids);

    Task<ICollection<TModel?>> GetAllRawModelsByIdsAsync(List<Guid> ids, CancellationToken cancellationToken);
    ICollection<TModel?> GetAllRawModelsByIds(List<Guid> ids);
}