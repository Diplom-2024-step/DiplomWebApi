using AnytourApi.Constants.Shared;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.Dtos.MyOwnValidationAttributes;
using Microsoft.AspNetCore.Http;
using WebApiForHikka.Dtos.MyOwnValidationAttribute;

namespace AnytourApi.Dtos.Dto.Models.Photos;

public class CreatePhotoDto
{
    [FileContentType("image/*", ErrorMessage = "content type problem")]
    [MaxFileSize(SharedNumberConstatnts.MaxFileSize)]
    public required IFormFile Photo { get; set; }

    [EntityValidation(typeof(Photoable), typeof(ReviewablePhotoable))] public required Guid PhotoableId { get; set; }

}
