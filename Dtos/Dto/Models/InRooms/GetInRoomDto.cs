using AnytourApi.Dtos.Shared;
using AnytourApi.Domain.Models.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.InRooms;

[ExportTsInterface]
public class GetInRoomDto : ModelDto
{
    public required string Name { get; set; }
}

