using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.InHotels;

[ExportTsInterface]
[ModelMetadataType(typeof(InHotel))]
public class CreateInHotelDto
{
    public required string Name { get; set; }
}
