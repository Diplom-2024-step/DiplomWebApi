using AnytourApi.Domain.Models.Enteties;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.OrderStatuses;

[ExportTsInterface]
[ModelMetadataType(typeof(OrderStatus))]
public class CreateOrderStatusDto
{
    public required string Name { get; set; }
}
