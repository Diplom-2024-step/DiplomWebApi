using AnytourApi.Domain.Models.Enteties;

namespace AnytourApi.Domain.Models.Shared;

public class Photoable : Model
{
    public required virtual ICollection<Photo> Photos { get; set; }
}
