using AnytourApi.Constants.Models.OrderStatuses;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class OrderStatus : Model
{
    [StringLength(OrderStatusNumberConstants.NameLength)]
    public required string Name { get; set; }
}

