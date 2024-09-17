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
}
