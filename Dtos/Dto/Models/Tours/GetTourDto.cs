using AnytourApi.Dtos.Dto.Models.Activities;
using AnytourApi.Dtos.Dto.Models.Cities;
using AnytourApi.Dtos.Dto.Models.DietTypes;
using AnytourApi.Dtos.Dto.Models.Hotels;
using AnytourApi.Dtos.Dto.Models.InHotels;
using AnytourApi.Dtos.Dto.Models.RoomTypes;
using AnytourApi.Dtos.Dto.Models.TransportationTypes;
using AnytourApi.Dtos.Dto.Users;
using AnytourApi.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.Tours;

[ExportTsInterface]
public class GetTourDto : ModelDto
{
    public required string Name { get; set; }

    public required GetHotelDto Hotel { get; set; }

    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }

    public required GetCityDto FromCity { get; set; }

    public required GetCityDto ToCity { get; set; }

    public required int PriceUSD { get; set; }

    public required string Description { get; set; }

    public required int Duration { get; set; }

    public required GetTransportationTypeDto TransportationType { get; set; }

    public required GetRoomTypeDto RoomType { get; set; }

    public required GetDietTypeDto DietType { get; set; }

    public required int HowManyAdults { get; set; }

    public required int HowManyKids { get; set; }


    public required List<string> Urls { get; set; } = [];

    public required List<GetActivityDto> Activities { get; set; } = [];
}
