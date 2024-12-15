using AnytourApi.Dtos.Dto.Users;
using AnytourApi.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.Reviews;

[ExportTsInterface]
public class GetReviewDto : ModelDto
{

    public required GetUserDto User { get; set; }


    public required string Body { get; set; }

    public required int Score { get; set; }

    public required DateTime CreatedAt { get; set; }

    public required Guid ReviewablePhotoableId { get; set; }


}
