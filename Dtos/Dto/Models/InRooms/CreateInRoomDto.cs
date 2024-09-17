using AnytourApi.Domain.Models.Enteties;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.InRooms;

[ExportTsInterface]
[ModelMetadataType(typeof(InRoom))]
public class CreateInRoomDto
{
    public required string Name { get; set; }
}

