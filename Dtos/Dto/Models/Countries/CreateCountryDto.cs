using AnytourApi.Domain.Models.Enteties;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.Countries;

[ExportTsInterface]
[ModelMetadataType(typeof(Country))]
public class CreateCountryDto
{
    public required string Name { get; set; }

    public required string Icon { get; set; }
}
