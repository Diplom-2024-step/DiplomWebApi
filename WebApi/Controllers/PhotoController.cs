using AnytourApi.Application.Services.Models.Photos;
using AnytourApi.Constants.Controller;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Photos;
using AnytourApi.Dtos.ResponseDto;
using AnytourApi.WebApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AnytourApi.WebApi.Controllers;

public class PhotoController(IPhotoService crudService, IHttpContextAccessor httpContextAccessor) : CrudController<GetPhotoDto, UpdatePhotoDto, CreatePhotoDto, IPhotoService, Photo, GetPhotoDto>(crudService, httpContextAccessor) 
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
    public virtual async Task<IActionResult> Put([FromForm] UpdatePhotoDto dto, CancellationToken cancellationToken)
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
}

