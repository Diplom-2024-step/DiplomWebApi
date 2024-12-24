using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.RoomTypes;

[ExportTsInterface]
[ModelMetadataType(typeof(RoomType))]
public class UpdateRoomTypeDto : ModelDto
{
    public required string Name { get; set; }
    public required int Price { get; set; }
}
