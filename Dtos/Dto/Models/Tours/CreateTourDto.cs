using AnytourApi.Domain.Models.Enteties;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;
using WebApiForHikka.Dtos.MyOwnValidationAttribute;

namespace AnytourApi.Dtos.Dto.Models.Tours;

[ExportTsInterface]
[ModelMetadataType(typeof(Tour))]
public class CreateTourDto
{
    public required string Name { get; set; }

    [EntityValidation(typeof(Hotel))] public required Guid HotelId { get; set; }

    public required DateTime SartDate { get; set; }

    public required DateTime EndDate { get; set; }

    [EntityValidation(typeof(City))] public required Guid FromCityId { get; set; }

    [EntityValidation(typeof(City))] public required Guid ToCityId { get; set; }

    public required int PriceUSD { get; set; }

    public required string Description { get; set; }

    public required int Duration { get; set; }

    [EntityValidation(typeof(TransportationType))] public required Guid TransportationTypeId { get; set; }

    [EntityValidation(typeof(RoomType))] public required Guid RoomTypeId { get; set; }

    [EntityValidation(typeof(DietType))] public required Guid DietTypeId { get; set; }

    public required int HowManyAdults { get; set; }

    public required int HowManyKids { get; set; }
}
