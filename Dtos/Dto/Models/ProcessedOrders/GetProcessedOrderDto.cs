using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models;
using TypeGen.Core.TypeAnnotations;
using AnytourApi.Dtos.Shared;
using AnytourApi.Dtos.Dto.Models.Orders;
using AnytourApi.Dtos.Dto.Users;
using AnytourApi.Dtos.Dto.Models.OrderStatuses;

namespace AnytourApi.Dtos.Dto.Models.ProcessedOrders;

[ExportTsInterface]
public class GetProcessedOrderDto : ModelDto
{
    public required virtual GetOrderDto Order { get; set; }

    public required virtual GetUserDto User { get; set; }

    public required virtual GetOrderStatusDto Status { get; set; }
}
