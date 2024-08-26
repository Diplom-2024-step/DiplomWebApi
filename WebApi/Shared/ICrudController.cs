using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AnytourApi.WebApi.Shared;

public interface ICrudController<TUpdateDto, TCreateDto>
{
    public Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken);
    public Task<IActionResult> Create([FromBody] TCreateDto dto, CancellationToken cancellationToken);

    public Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken);

    public Task<IActionResult> Put([FromBody] TUpdateDto dto, CancellationToken cancellationToken);

    public Task<IActionResult> GetAll([FromBody] FilterPaginationDto paginationDto,
        CancellationToken cancellationToken);
}