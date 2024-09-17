using AnytourApi.Domain.Models.Enteties;

namespace AnytourApi.Domain.Models.Shared;

public  class Reviewable : Model
{
    public required virtual ICollection<Review> Reviews { get; set; } = [];
}
