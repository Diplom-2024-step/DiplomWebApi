﻿using AnytourApi.Dtos.Shared;
using AnytourApi.Domain.Models.Shared;
using TypeGen.Core.TypeAnnotations;
using AnytourApi.Dtos.Dto.Models.Countries;

namespace AnytourApi.Dtos.Dto.Models.Activities;

[ExportTsInterface]
public class GetActivityDto : ModelDto
{
    public required string Name { get; set; }

    public required string Description  { get; set; }

    public required List<string> Urls { get; set; } = [];

    public required GetCountryDto Country { get; set; }
    
    public required int Price { get; set; }
}
