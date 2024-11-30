using AnytourApi.Application.Services.Models.RoomTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.RoomTypes;
using AnytourApi.Dtos.Shared;
using AnytourApi.WebApi.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnytourApi.WebApi.Controllers;

public class RoomTypeController(IRoomTypeService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetRoomTypeDto,
    UpdateRoomTypeDto,
    CreateRoomTypeDto,
    IRoomTypeService,
    RoomType,
    GetRoomTypeDto>(CrudService, HttpContextAccessor)
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
