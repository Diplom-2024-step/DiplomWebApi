using AnytourApi.Domain.Models.Enteties;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.ForSports;

[ExportTsInterface]
[ModelMetadataType(typeof(ForSport))]
public class CreateForSportDto
{
    public required string Name { get; set; }
}

