using AnytourApi.Dtos.Shared;
using AnytourApi.Domain.Models.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.OrderStatuses;

[ExportTsInterface]
public class GetOrderStatusDto : ModelDto
{
    public required string Name { get; set; }
}

