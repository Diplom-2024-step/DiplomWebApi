using AnytourApi.Constants.Models.Orders;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class Order : Model
{
    public required virtual Tour Tour { get; set; }

    [Range(OrderNumberConstants.MinPriceUSD, int.MaxValue)]
    public required int PriceUSD { get; set; }

    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }

    [StringLength(OrderNumberConstants.MobilePhoneNumberLength)]
    public required string MobilePhoneNumber { get; set; }

    [StringLength(OrderNumberConstants.FulNameLength)]
    public required string FullName { get; set; }

    public required virtual User? User { get; set; }

    public required virtual User? Admin { get; set; }

    public required virtual OrderStatus OrderStatus { get; set; }
}
