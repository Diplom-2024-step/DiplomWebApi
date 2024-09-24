using AnytourApi.Dtos.Dto.Models.OrderStatuses;
using AnytourApi.Dtos.Dto.Models.Tours;
using AnytourApi.Dtos.Dto.Users;
using AnytourApi.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.Orders;

[ExportTsInterface]
public class GetOrderDto : ModelDto
{
    public required virtual GetTourDto Tour { get; set; }

    public required int PriceUSD { get; set; }

    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }

    public required string MobilePhoneNumber { get; set; }

    public required string FullName { get; set; }

    public required virtual GetUserDto? User { get; set; }

    public required virtual GetUserDto? Admin { get; set; }

    public required virtual GetOrderStatusDto OrderStatus { get; set; }
}
