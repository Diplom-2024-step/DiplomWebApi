using AnytourApi.Constants.Models.Cities;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class City : Model
{
    [StringLength(CityNumberConstants.NameLength)]
    public required string Name { get; set; }

    public required double Latitud { get; set; }
    public required double Longitud { get; set; }
    public required virtual Country Country { get; set; }

}
