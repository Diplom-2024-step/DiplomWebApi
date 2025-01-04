using AnytourApi.Constants.Models.ReviewOnCompanies;
using AnytourApi.Domain.Models;
using AnytourApi.Dtos.Dto.Users;
using AnytourApi.Dtos.Shared;
using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Models.ReviewOnComapnies;

[ExportTsInterface]
public class GetReviewOnCompanyDto : ModelDto
{

    public required int PriceQuality { get; set; }

    public required int Dwelling { get; set; }


    public required int OrganizationOfTrips { get; set; }


    public required int Service { get; set; }


    public required string Body { get; set; }

    public required GetUserDto User { get; set; }

    public DateTime CreatedAt { get; set; }

    public int Score { get; set; }
}
