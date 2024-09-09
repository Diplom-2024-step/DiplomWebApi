using AnytourApi.Constants.Shared;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.Dtos.MyOwnValidationAttributes;
using Microsoft.AspNetCore.Http;
using WebApiForHikka.Dtos.MyOwnValidationAttribute;

namespace AnytourApi.Dtos.Dto.Models.Photos;

public class CreatePhotoDto
{
    [FileContentType("image/*")]
    [MaxFileSize(SharedNumberConstatnts.MaxFileSize)]
    public required IFormFile Photo { get; set; }

    [EntityValidation<Photoable>] public required Guid PhotoableId { get; set; }

}
