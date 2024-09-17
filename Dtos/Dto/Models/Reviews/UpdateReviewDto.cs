using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;
using WebApiForHikka.Dtos.MyOwnValidationAttribute;

namespace AnytourApi.Dtos.Dto.Models.Reviews;


[ExportTsInterface]
[ModelMetadataType(typeof(Review))]
public class UpdateReviewDto : ModelDto
{
    public required string Body { get; set; }

    public required int Score { get; set; }

    [EntityValidation(typeof(Reviewable), typeof(ReviewablePhotoable))] public required Guid ReviewablePhotoableId { get; set; }


}
