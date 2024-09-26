using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class ProcessedOrder : Model
{
    public required virtual Order Order { get; set; }

    public required virtual User User { get; set; }

    public required virtual OrderStatus Status { get; set; }
}
