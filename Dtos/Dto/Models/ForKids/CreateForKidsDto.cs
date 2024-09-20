﻿using AnytourApi.Domain.Models.Enteties;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.ForKids;

[ExportTsInterface]
[ModelMetadataType(typeof(ForKid))]
public class CreateForKidsDto
{
    public required string Name { get; set; }
}
