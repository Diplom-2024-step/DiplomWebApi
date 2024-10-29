using AnytourApi.Application.Services.Models.Photos;
using AnytourApi.Constants.Controller;
using AnytourApi.Constants.Models.Photos;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Photos;
using AnytourApi.Dtos.ResponseDto;
using AnytourApi.Infrastructure.FileHelper;
using AnytourApi.WebApi.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace AnytourApi.WebApi.Controllers;

[AllowAnonymous]
public class PhotoController(IPhotoService crudService, IFileHelper fileHelper,  IHttpContextAccessor httpContextAccessor) : CrudController<GetPhotoDto, UpdatePhotoDto, CreatePhotoDto, IPhotoService, Photo, GetPhotoDto>(crudService, httpContextAccessor) 
{

    [HttpPost]
    public override async Task<IActionResult> Create([FromForm] CreatePhotoDto dto, CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(
            new ThingsToValidateBase());
        if (errorEndPoint.IsError) return errorEndPoint.GetError();


        Guid? id = await CrudService.CreateAsync(dto, cancellationToken);

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (id == null) return BadRequest(ControllerStringConstants.SomethingWentWrongDuringCreateing);

        return Ok(new CreateResponseDto { Id = (Guid)id });
    }



    [HttpPut]
    public override async Task<IActionResult> Put([FromForm] UpdatePhotoDto dto, CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequestForUpdateEndPoint(
            new ThingsToValidateForUpdate
            {
                UpdateDto = dto
            });

        if (errorEndPoint.IsError) return errorEndPoint.GetError();

        await CrudService.UpdateAsync(dto, cancellationToken);
        return NoContent();
    }


    [AllowAnonymous]
    [HttpGet("displayImage/{imageId}")]
    public async Task<IActionResult> DisplayImage([FromRoute] Guid imageId, CancellationToken cancellationToken)
    {
        var imagePath = await CrudService.GetPathAsync(imageId, cancellationToken);

        if (!System.IO.File.Exists(imagePath))
        {
            return NotFound($"Image not found for id: {imageId}");
        }

        var mimeType = GetMimeType(imagePath);

        return PhysicalFile(imagePath, mimeType, Path.GetFileName(imagePath));
    }

    private string GetMimeType(string filePath)
    {
        var provider = new FileExtensionContentTypeProvider();
        if (provider.TryGetContentType(filePath, out string contentType))
        {
            return contentType;
        }
        return "application/octet-stream";
    }
}

