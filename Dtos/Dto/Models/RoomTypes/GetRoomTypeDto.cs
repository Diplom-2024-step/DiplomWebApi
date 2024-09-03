using AnytourApi.Domain.Models.Shared;
using AnytourApi.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.RoomTypes;

[ExportTsInterface]
public class GetRoomTypeDto : ModelDto
{
    public required string Name { get; set; }
}
