using AnytourApi.Constants.Models.InRoom;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;
public class InRoom : Model
{
    [StringLength(InRoomNumberConstants.NameLength)]
    public required string Name { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}

