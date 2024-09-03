using AnytourApi.Domain.Models.Shared;
using AnytourApi.Dtos.Dto.Models.Cities;
using AnytourApi.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.Hotels;

[ExportTsInterface]
public class GetHotelDto : ModelDto
{
    public required GetCityDto City { get; set; }

    public required string Name { get; set; }


    public required string Description { get; set; }

    public required int Stars { get; set; }


    public required int HowManyRooms { get; set; }

    public required string DescriptionLocation { get; set; }

    public required string DescriptionForKids { get; set; }

    public required string DescriptionForSports { get; set; }

    public required string DescriptionForInHotels { get; set; }

    public required string DescriptionForBeachTypes { get; set; }

    public int? TurpravdaScore { get; set; }

    public long? TurpravdaId { get; set; }

    public required double Latitud { get; set; }

    public required double Longitud { get; set; }

    public required string Adress { get; set; }
}
