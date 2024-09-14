using AnytourApi.Domain.Models.Enteties;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;
using WebApiForHikka.Dtos.MyOwnValidationAttribute;

namespace AnytourApi.Dtos.Dto.Models.Cities;

[ExportTsInterface]
[ModelMetadataType(typeof(City))]
public class CreateCityDto
{
    [EntityValidation(typeof(Country))] public required Guid CountryId { get; set; }

    public required string Name { get; set; }

    public required double Latitud { get; set; }

    public required double Longitud { get; set; }

}
