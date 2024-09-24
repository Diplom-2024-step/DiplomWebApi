using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;
using WebApiForHikka.Dtos.MyOwnValidationAttribute;

namespace AnytourApi.Dtos.Dto.Models.Orders;

[ExportTsInterface]
[ModelMetadataType(typeof(Order))]
public class UpdateOrderDto : ModelDto
{
    [EntityValidation(typeof(Tour))] public required Guid TourId { get; set; }

    public required int PriceUSD { get; set; }

    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }

    public required string MobilePhoneNumber { get; set; }

    public required string FullName { get; set; }

    [EntityValidation(typeof(User))] public required Guid? UserId { get; set; }

    [EntityValidation(typeof(User))] public required Guid? AdminId { get; set; }

    [EntityValidation(typeof(OrderStatus))] public required Guid OrderStatusId { get; set; }
}
