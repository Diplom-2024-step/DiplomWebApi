using AnytourApi.Constants.Models.Hotels;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class Hotel : ReviewablePhotoable  
{
    public required virtual City City { get; set; }

    [StringLength(HotelNumberConstants.NameLength)]
    public required string Name { get; set; }


    [StringLength(HotelNumberConstants.DescriptionLength)]
    public required string Description { get; set; }

    [Range(HotelNumberConstants.MinStrats, HotelNumberConstants.MaxStrats)]
    public required int Stars { get; set; }


    [Range(HotelNumberConstants.MinNumberOfRooms, int.MaxValue)]
    public required int HowManyRooms { get; set; }

    [StringLength(HotelNumberConstants.DescriptionLocationLength)]
    public required string DescriptionLocation { get; set; }

    [StringLength(HotelNumberConstants.DescriptionForKidsLength)]
    public required string DescriptionForKids { get; set; }

    [StringLength(HotelNumberConstants.DescriptionForSportsLength)]
    public required string DescriptionForSports { get; set; }

    [StringLength(HotelNumberConstants.DescriptionForInHotelsLength)]
    public required string DescriptionForInHotels { get; set; }

    [StringLength(HotelNumberConstants.DescriptionForBeachTypesLength)]
    public required string DescriptionForBeachTypes { get; set; }

    [Range(HotelNumberConstants.MinTourPravdaScore, HotelNumberConstants.MaxTourPravdaScore)]
    public int? TurpravdaScore { get; set; }

    [Range(0, long.MaxValue)]
    public long? TurpravdaId { get; set; }  

    public required double Latitud { get; set; }    

    public required double Longitud { get; set; }

    [StringLength(HotelNumberConstants.AdressLength)]
    public required string Adress { get; set; }

    public virtual ICollection<InHotel> InHotels { get; set; } = new List<InHotel>();
    public virtual ICollection<BeachType> BeachTypes { get; set; } = new List<BeachType>();
    public virtual ICollection<ForSport> ForSports { get; set; } = new List<ForSport>();
    public virtual ICollection<RoomType> RoomTypes { get; set; } = new List<RoomType>();
    public virtual ICollection<DietType> DietTypes { get; set; } = new List<DietType>();
    public virtual ICollection<ForKid> ForKids { get; set; } = new List<ForKid>();
    public virtual ICollection<InRoom> InRooms { get; set; } = new List<InRoom>();
}
