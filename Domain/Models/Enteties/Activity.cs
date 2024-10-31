using AnytourApi.Constants.Models.Activites;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class Activity : ReviewablePhotoable
{
    [StringLength(ActivityNumberConstants.NameLength)]
    public required string Name { get; set; }


    [StringLength(ActivityNumberConstants.DescriptionLength)]
    public required string Description { get; set; }


    [Range(0, ActivityNumberConstants.MaxPrice)]
    public required int Price { get; set; }

    public required virtual Country Country { get; set; }

    public required virtual ICollection<Tour> Tours { get; set; }

}
