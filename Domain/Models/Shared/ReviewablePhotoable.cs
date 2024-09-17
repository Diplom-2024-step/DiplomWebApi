using AnytourApi.Domain.Models.Enteties;

namespace AnytourApi.Domain.Models.Shared;

public class ReviewablePhotoable : Photoable
{
    public required virtual ICollection<Review> Reviews { get; set; } = [];
}
