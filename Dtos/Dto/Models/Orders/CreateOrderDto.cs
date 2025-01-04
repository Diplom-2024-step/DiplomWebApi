using AnytourApi.Constants.Models.Tours;
using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;
using WebApiForHikka.Dtos.MyOwnValidationAttribute;

namespace AnytourApi.Dtos.Dto.Models.Orders;

[ExportTsInterface]
[ModelMetadataType(typeof(Order))]
public class CreateOrderDto
{
    [EntityValidation(typeof(Hotel))] public required Guid HotelId { get; set; }

    public required int PriceUSD { get; set; }

    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }

    public required string MobilePhoneNumber { get; set; }

    public required string FullName { get; set; }

    [EntityValidation(typeof(User))] public required Guid? UserId { get; set; }

    [EntityValidation(typeof(User))] public required Guid? AdminId { get; set; }

    public required string OrderStatus { get; set; }


    public required int Duration { get; set; }

    [EntityValidation(typeof(TransportationType))] public required Guid TransportationTypeId { get; set; }

    [EntityValidation(typeof(RoomType))] public required Guid RoomTypeId { get; set; }

    [EntityValidation(typeof(DietType))] public required Guid DietTypeId { get; set; }

    public required int HowManyAdults { get; set; }

    public required int HowManyKids { get; set; }

    [EntityValidation(typeof(City))] public required virtual Guid FromCityId { get; set; }

    [EntityValidation(typeof(City))] public required virtual Guid ToCityId { get; set; }

    [EntityValidation(typeof(Activity))] public required List<Guid> ActivityIds { get; set; }    

    [EntityValidation(typeof(Tour))] public Guid? TourId { get; set; }
}
