using AnytourApi.Domain.Models.Shared;
using AnytourApi.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.InHotels;

[ExportTsInterface]
public class GetInHotelDto : ModelDto
{
    public required string Name { get; set; }
}
