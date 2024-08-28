using AnytourApi.Domain.Models.Shared;
using AnytourApi.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.ForSports;

[ExportTsInterface]
public class GetForSportDto : ModelDto
{
    public required string Name { get; set; }
}

