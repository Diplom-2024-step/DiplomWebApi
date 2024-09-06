using AnytourApi.Constants.Models.Countries;
using AnytourApi.Constants.Models.InHotels;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class InHotel : Model
{
    [StringLength(InHotelsNumberConstant.NameLength)]
    public required string Name { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}

