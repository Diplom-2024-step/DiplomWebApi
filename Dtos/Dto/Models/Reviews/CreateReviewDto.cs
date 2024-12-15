using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;
using WebApiForHikka.Dtos.MyOwnValidationAttribute;

namespace AnytourApi.Dtos.Dto.Models.Reviews;

[ExportTsInterface]
[ModelMetadataType(typeof(Review))]
public class CreateReviewDto
{
    public required string Body { get; set; }

    public required int Score { get; set; }

    [EntityValidation(typeof(Reviewable), typeof(ReviewablePhotoable))] public required Guid ReviewablePhotoableId { get; set; }


    [EntityValidation(typeof(User))] public required Guid UserId { get; set; }   


}
