using AnytourApi.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.BeachTypes;

[ExportTsInterface]
public class GetBeachTypeDto : ModelDto
{
    public required string Name { get; set; }
}
