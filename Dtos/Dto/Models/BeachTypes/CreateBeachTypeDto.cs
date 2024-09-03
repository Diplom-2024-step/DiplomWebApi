using AnytourApi.Domain.Models.Enteties;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.BeachTypes;

[ExportTsInterface]
[ModelMetadataType(typeof(BeachType))]
public class CreateBeachTypeDto
{
    public required string Name { get; set; }
}
