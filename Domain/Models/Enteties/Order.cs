using AnytourApi.Constants.Models.Orders;
using AnytourApi.Constants.Models.Tours;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class Order : Model
{
    public required virtual Hotel Hotel { get; set; }

    [Range(OrderNumberConstants.MinPriceUSD, int.MaxValue)]
    public required int PriceUSD { get; set; }

    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }

    [StringLength(OrderNumberConstants.MobilePhoneNumberLength)]
    public required string MobilePhoneNumber { get; set; }

    [StringLength(OrderNumberConstants.FulNameLength)]
    public required string FullName { get; set; }

    public required virtual User? User { get; set; }

    public required virtual User? Admin { get; set; }

    public required virtual OrderStatus OrderStatus { get; set; }


    [Range(TourNumberConstants.MinDuration, TourNumberConstants.MaxDuration)]
    public required int Duration { get; set; }

    public required virtual TransportationType TransportationType { get; set; }

    public required virtual RoomType RoomType { get; set; }

    public required virtual DietType DietType { get; set; }

    [Range(TourNumberConstants.MinhHowManyAdults, TourNumberConstants.MaxHowManyAdults)]
    public required int HowManyAdults { get; set; }

    [Range(TourNumberConstants.MinhHowManyKids, TourNumberConstants.MaxHowManyKids)]
    public required int HowManyKids { get; set; }

    public required virtual City FromCity { get; set; }

    public required virtual City ToCity { get; set; }

    public required virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();  



}
