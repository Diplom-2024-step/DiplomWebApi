using AnytourApi.Domain.Models.Shared;
using AnytourApi.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.DietTypes;

[ExportTsInterface]
public class GetDietTypeDto : ModelDto
{
    public required string Name { get; set; }
}
