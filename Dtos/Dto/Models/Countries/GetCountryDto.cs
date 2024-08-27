using AnytourApi.Domain.Models.Shared;
using AnytourApi.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.Countries;

[ExportTsInterface]
public class GetCountryDto : ModelDto
{
    public required string Name { get; set; }
    public required string Icon { get; set; }

}
