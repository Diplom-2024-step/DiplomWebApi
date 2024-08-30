using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.InHotels;
    
[ExportTsInterface]
[ModelMetadataType(typeof(InHotel))]

public class UpdateInHotelDto : ModelDto
{
    public required string Name { get; set; }
}

