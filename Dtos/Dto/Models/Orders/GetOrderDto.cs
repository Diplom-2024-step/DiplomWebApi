using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Cities;
using AnytourApi.Dtos.Dto.Models.DietTypes;
using AnytourApi.Dtos.Dto.Models.Hotels;
using AnytourApi.Dtos.Dto.Models.OrderStatuses;
using AnytourApi.Dtos.Dto.Models.RoomTypes;
using AnytourApi.Dtos.Dto.Models.Tours;
using AnytourApi.Dtos.Dto.Models.TransportationTypes;
using AnytourApi.Dtos.Dto.Users;
using AnytourApi.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;
using WebApiForHikka.Dtos.MyOwnValidationAttribute;

namespace AnytourApi.Dtos.Dto.Models.Orders;

[ExportTsInterface]
public class GetOrderDto : ModelDto
{
    public required  GetHotelDto Hotel { get; set; }

    public required int PriceUSD { get; set; }

    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }

    public required string MobilePhoneNumber { get; set; }

    public required string FullName { get; set; }

    public required virtual GetUserDto? User { get; set; }

    public required virtual GetUserDto? Admin { get; set; }

    public required virtual GetOrderStatusDto OrderStatus { get; set; }

    public required int Duration { get; set; }

    public required GetTransportationTypeDto TransportationType { get; set; }

     public required GetRoomTypeDto RoomType { get; set; }

    public required GetDietTypeDto DietType { get; set; }

    public required int HowManyAdults { get; set; }

    public required int HowManyKids { get; set; }

    public required  GetCityDto FromCity { get; set; }

    public required  GetCityDto ToCity { get; set; }
}
