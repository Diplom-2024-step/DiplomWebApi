using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;


namespace AnytourApi.Dtos.Dto.Models.Activities;

[ExportTsInterface]
[ModelMetadataType(typeof(Activity))]
public class UpdateActivityDto : ModelDto
{
    public required string Name { get; set; }
}
