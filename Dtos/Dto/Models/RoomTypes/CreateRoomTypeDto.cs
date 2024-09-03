using AnytourApi.Domain.Models.Enteties;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;


namespace AnytourApi.Dtos.Dto.Models.RoomTypes;

[ExportTsInterface]
[ModelMetadataType(typeof(RoomType))]
public class CreateRoomTypeDto
{
    public required string Name { get; set; }
}
