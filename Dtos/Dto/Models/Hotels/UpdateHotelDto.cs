﻿using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;
using WebApiForHikka.Dtos.MyOwnValidationAttribute;

namespace AnytourApi.Dtos.Dto.Models.Hotels;


[ExportTsInterface]
[ModelMetadataType(typeof(Hotel))]
public class UpdateHotelDto : ModelDto
{
    [EntityValidation(typeof(City))] public required Guid CityId { get; set; }

    [EntityValidation(typeof(InHotel))] public required List<Guid> InHotelIds { get; set; }

    [EntityValidation(typeof(ForSport))] public required List<Guid> ForSportIds { get; set; }

    [EntityValidation(typeof(BeachType))] public required List<Guid> BeachTypesIds { get; set; }

    [EntityValidation(typeof(RoomType))] public required List<Guid> RoomTypeIds { get; set; }

    public required string Name { get; set; }


    public required string Description { get; set; }

    public required int Stars { get; set; }


    public required int HowManyRooms { get; set; }

    public required string DescriptionLocation { get; set; }

    public required string DescriptionForKids { get; set; }

    public required string DescriptionForSports { get; set; }

    public required string DescriptionForInHotels { get; set; }

    public required string DescriptionForBeachTypes { get; set; }

    public int? TurpravdaScore { get; set; }

    public long? TurpravdaId { get; set; }

    public required double Latitud { get; set; }

    public required double Longitud { get; set; }

    public required string Adress { get; set; }
}
