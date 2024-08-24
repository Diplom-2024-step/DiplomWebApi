using Domain;
using Domain.Models.Shared;
using Dtos.Shared;

namespace Application.Services.Shared;

public interface ICrudService<TGetDto, TCreateDto, TUpdateDto, TModel>
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
    Task<ReturnPageDto<TGetDto>> GetAllAsync(FilterPaginationDto dto, CancellationToken cancellationToken);
    Task<ICollection<TGetDto?>> GetAllModelsByIdsAsync(List<Guid> ids, CancellationToken cancellationToken);
    ICollection<TGetDto?> GetAllModelsByIds(List<Guid> ids);
}