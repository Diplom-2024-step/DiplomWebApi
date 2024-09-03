using AnytourApi.Dtos.Dto.Models.Countries;
using AnytourApi.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.Cities;

[TsDefaultExport]
public class GetCityDto : ModelDto
{
    public required GetCountryDto  Country { get; set; }

    public required string Name { get; set; }

    public required double Latitud { get; set; }

    public required double Longitud { get; set; }


}
