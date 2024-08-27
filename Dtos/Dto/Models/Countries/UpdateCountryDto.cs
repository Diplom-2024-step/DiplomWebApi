using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.Countries;

[ExportTsInterface]
[ModelMetadataType(typeof(Country))]
public class UpdateCountryDto : ModelDto
{
    public required string Name { get; set; }
    public required string Icon { get; set; }
}
