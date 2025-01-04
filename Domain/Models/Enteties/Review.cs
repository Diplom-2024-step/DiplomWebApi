using AnytourApi.Constants.Models.Reviews;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class Review : Model
{

    public required virtual User User { get; set; }

    public DateTime CreatedAt { get; set; }



    [StringLength(ReviewNumberConstants.BodyLength)]
    public required string Body { get; set; }

    [Range(ReviewNumberConstants.MinScore, ReviewNumberConstants.MaxScore)]
    public required int Score { get; set; }

   
    public required Guid ReviewablePhotoableId { get; set; }

}
