using AnytourApi.Constants.Models.ReviewOnCompanies;
using AnytourApi.Constants.Models.Reviews;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class ReviewOnCompany : Model
{

    [Range(ReviewOnCompanyNumberConstants.PriceQualityMin, ReviewOnCompanyNumberConstants.PriceQualityMax)]
    public required int PriceQuality { get; set; }


    [Range(ReviewOnCompanyNumberConstants.DwellingMin, ReviewOnCompanyNumberConstants.DwellingMax)]
    public required int Dwelling { get; set; }



    [Range(ReviewOnCompanyNumberConstants.OrganizationOfTripsMin, ReviewOnCompanyNumberConstants.OrganizationOfTripsMax)]
    public required int OrganizationOfTrips { get; set; }


    [Range(ReviewOnCompanyNumberConstants.ServiceMin, ReviewOnCompanyNumberConstants.ServiceMax)]
    public required int Service { get; set; }


    [StringLength(ReviewOnCompanyNumberConstants.BodyMaxLength)]
    public required string Body { get; set; }

    public required virtual User User { get; set; }

    public DateTime CreatedAt { get; set; }


    [Range(ReviewOnCompanyNumberConstants.ScoreMin, ReviewOnCompanyNumberConstants.ScoreMax)]
    public int Score { get; set; }

}
