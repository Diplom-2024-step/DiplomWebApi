using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.TransportationTypes;

[ExportTsInterface]
[ModelMetadataType(typeof(TransportationType))]
public class UpdateTransportationTypeDto : ModelDto
{
    public required string Name { get; set; }
}
