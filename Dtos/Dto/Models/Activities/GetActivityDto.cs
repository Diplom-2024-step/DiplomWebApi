using AnytourApi.Dtos.Shared;
using AnytourApi.Domain.Models.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.Activities;

[ExportTsInterface]
public class GetActivityDto : ModelDto
{
    public required string Name { get; set; }
}
