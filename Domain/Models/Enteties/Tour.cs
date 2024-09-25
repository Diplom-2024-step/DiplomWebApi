using AnytourApi.Constants.Models.Tours;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class Tour : ReviewablePhotoable
{
    [StringLength(TourNumberConstants.NameLength)]
    public required string Name { get; set; }

    public required virtual Hotel Hotel { get; set; }

    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }

    public required virtual City FromCity { get; set; }

    public required virtual City ToCity { get; set; }

    public required int PriceUSD { get; set; }

    [StringLength(TourNumberConstants.DescriptionLength)]
    public required string Description { get; set; }

    [Range(TourNumberConstants.MinDuration, TourNumberConstants.MaxDuration)]
    public required int Duration {  get; set; }

    public required virtual TransportationType TransportationType { get; set; }

    public required virtual RoomType RoomType { get; set; }

    public required virtual DietType DietType { get; set; }

    [Range(TourNumberConstants.MinhHowManyAdults, TourNumberConstants.MaxHowManyAdults)]
    public required int HowManyAdults { get; set; }

    [Range(TourNumberConstants.MinhHowManyKids, TourNumberConstants.MaxHowManyKids)]
    public required int HowManyKids { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
