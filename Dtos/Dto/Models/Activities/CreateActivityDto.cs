using AnytourApi.Domain.Models.Enteties;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.Activities;

[ExportTsInterface]
[ModelMetadataType(typeof(Activity))]
public class CreateActivityDto
{
    public required string Name { get; set; }
}
