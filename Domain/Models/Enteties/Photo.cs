using AnytourApi.Constants.Models.Photos;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class Photo : Model
{
    [StringLength(PhotoNumberConstants.PathLength)]
    public required string Path { get; set; }

    [Range(0, int.MaxValue)]
    public required int Width { get; set; }

    [Range(0, int.MaxValue)]
    public required int Height { get; set; }

    public required Guid PhotoableId { get; set; }
}
