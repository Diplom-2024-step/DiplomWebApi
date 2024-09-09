using AnytourApi.Dtos.Shared;

namespace AnytourApi.Dtos.Dto.Models.Photos;

public class GetPhotoDto : ModelDto
{
    public required string Url { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }



}
