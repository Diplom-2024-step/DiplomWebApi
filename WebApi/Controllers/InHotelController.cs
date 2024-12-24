using AnytourApi.Application.Services.Models.InHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.InHotels;
using AnytourApi.Dtos.Shared;
using AnytourApi.WebApi.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnytourApi.WebApi.Controllers;

public class InHotelController(IInHotelService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetInHotelDto,
    UpdateInHotelDto,
    CreateInHotelDto,
    IInHotelService,
    InHotel,
    GetInHotelDto>(CrudService, HttpContextAccessor)
{
    [HttpGet("{id:Guid}")]
    [AllowAnonymous]
    public override async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(
            new ThingsToValidateBase());
        if (errorEndPoint.IsError) return errorEndPoint.GetError();


        var model = await CrudService.GetAsync(id, cancellationToken);
        if (model is null)
            return NotFound();

        return Ok(model);
    }


    [HttpPost("GetAll")]
    [AllowAnonymous]
    public override async Task<IActionResult> GetAll([FromBody] FilterPaginationDto paginationDto,
        CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(
            new ThingsToValidateBase());


        if (errorEndPoint.IsError) return errorEndPoint.GetError();

        var page = await CrudService.GetAllAsync(paginationDto, cancellationToken);

        return Ok(page
                   );
    }


}
