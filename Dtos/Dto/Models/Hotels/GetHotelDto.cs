using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.Dtos.Dto.Models.BeachTypes;
using AnytourApi.Dtos.Dto.Models.Cities;
using AnytourApi.Dtos.Dto.Models.DietTypes;
using AnytourApi.Dtos.Dto.Models.ForKids;
using AnytourApi.Dtos.Dto.Models.ForSports;
using AnytourApi.Dtos.Dto.Models.InHotels;
using AnytourApi.Dtos.Dto.Models.InRooms;
using AnytourApi.Dtos.Dto.Models.RoomTypes;
using AnytourApi.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.Hotels;

[ExportTsInterface]
public class GetHotelDto : ModelDto
{
    public required GetCityDto City { get; set; }

    public required List<GetInHotelDto> InHotels { get; set; }

    public required List<GetForSportDto> ForSports { get; set; }

    public required List<GetBeachTypeDto> BeachTypes { get; set; }

    public required List<GetRoomTypeDto> RoomTypes { get; set; }

    public required List<GetInRoomDto> InRooms { get; set; }

    public required List<GetForKidDto> ForKids { get; set; }

    public required List<GetDietTypeDto> DietTypes { get; set; }


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

    public required int PricePerNight { get; set; }

    public required int AdditionCostPerPerson { get; set; }

    public required List<string> Urls { get; set; } = [];

    public required string WebSiteUrl { get; set; }
    public required string Email { get; set; }

    public required string TelephoneNumber { get; set; }

}
