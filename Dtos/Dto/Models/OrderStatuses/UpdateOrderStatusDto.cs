using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Dtos.Dto.Models.OrderStatuses;

[ExportTsInterface]
[ModelMetadataType(typeof(OrderStatus))]
public class UpdateOrderStatusDto : ModelDto
{
    public required string Name { get; set; }
}
