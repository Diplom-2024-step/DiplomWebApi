using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TypeGen.Core.TypeAnnotations;
using WebApiForHikka.Dtos.MyOwnValidationAttribute;

namespace AnytourApi.Dtos.Dto.Models.ReviewOnComapnies;


[ExportTsInterface]
[ModelMetadataType(typeof(ReviewOnCompany))]
public class CreateReviewOnCompanyDto
{
    public required int PriceQuality { get; set; }

    public required int Dwelling { get; set; }


    public required int OrganizationOfTrips { get; set; }


    public required int Service { get; set; }


    public required string Body { get; set; }

    public int Score { get; set; }

    [EntityValidation(typeof(User))] public required Guid UserId { get; set; }   
}
