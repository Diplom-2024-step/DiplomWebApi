using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Dtos.Dto.Models.InRooms;

[ExportTsInterface]
[ModelMetadataType(typeof(InRoom))]
public class UpdateInRoomDto : ModelDto
{
    public required string Name { get; set; }
}

