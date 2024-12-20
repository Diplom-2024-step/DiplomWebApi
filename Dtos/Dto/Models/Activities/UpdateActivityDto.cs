﻿using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;
using System.ComponentModel.DataAnnotations;
using WebApiForHikka.Dtos.MyOwnValidationAttribute;


namespace AnytourApi.Dtos.Dto.Models.Activities;

[ExportTsInterface]
[ModelMetadataType(typeof(Activity))]
public class UpdateActivityDto : ModelDto
{
    public required string Name { get; set; }
    

    public required string Description  { get; set; }

    [EntityValidation(typeof(Country))] public required Guid CountryId { get; set; }

    public required int Price { get; set; }
}
