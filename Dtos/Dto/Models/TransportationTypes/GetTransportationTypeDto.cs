using AnytourApi.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.TransportationTypes;

[ExportTsInterface]
public class GetTransportationTypeDto : ModelDto
{
    public required string Name { get; set; }
}
