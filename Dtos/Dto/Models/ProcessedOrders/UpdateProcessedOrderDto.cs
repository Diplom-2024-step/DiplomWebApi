using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;
using WebApiForHikka.Dtos.MyOwnValidationAttribute;

namespace AnytourApi.Dtos.Dto.Models.ProcessedOrders;

[ExportTsInterface]
[ModelMetadataType(typeof(ProcessedOrder))]
public class UpdateProcessedOrderDto : ModelDto
{
    [EntityValidation(typeof(Order))] public required Guid OrderId { get; set; }

    [EntityValidation(typeof(User))] public required Guid UserId { get; set; }

    [EntityValidation(typeof(OrderStatus))] public required Guid StatusId { get; set; }
}
