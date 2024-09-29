using AnytourApi.Dtos.Shared;
using AnytourApi.Domain.Models.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.ForKids;

[ExportTsInterface]
public class GetForKidDto : ModelDto
{
    public required string Name { get; set; }
}

