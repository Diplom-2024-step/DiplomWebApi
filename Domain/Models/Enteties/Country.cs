using AnytourApi.Constants.Models.Countries;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class Country : Model
{

    [StringLength(CountryNumberConstants.IconLength)]
    public required string Icon { get; set; }

    [StringLength(CountryNumberConstants.NameLength)]
    public required string Name { get; set; }

}
