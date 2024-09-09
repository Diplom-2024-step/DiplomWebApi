using AnytourApi.Constants.Models.ForSports;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class ForSport : Model
{
    [StringLength(ForSportsNumberConstants.NameLength)]
    public required string Name { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
