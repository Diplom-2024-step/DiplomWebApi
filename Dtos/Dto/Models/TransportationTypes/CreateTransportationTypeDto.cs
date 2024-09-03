using AnytourApi.Domain.Models.Enteties;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.TransportationTypes;

[ExportTsInterface]
[ModelMetadataType(typeof(TransportationType))]
public class CreateTransportationTypeDto
{
    public required string Name { get; set; }
}
