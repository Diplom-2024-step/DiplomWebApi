using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.DietTypes;

[ExportTsInterface]
[ModelMetadataType(typeof(DietType))]
public class UpdateDietTypeDto : ModelDto
{
    public required string Name { get; set; }
}
