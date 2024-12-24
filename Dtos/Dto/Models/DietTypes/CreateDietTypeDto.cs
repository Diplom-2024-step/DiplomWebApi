using AnytourApi.Domain.Models.Enteties;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.DietTypes;

[ExportTsInterface]
[ModelMetadataType(typeof(DietType))]
public class CreateDietTypeDto
{
    public required string Name { get; set; }

    public required int Price { get; set; }
}
