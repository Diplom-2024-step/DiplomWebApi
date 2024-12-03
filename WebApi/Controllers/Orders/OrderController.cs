using AnytourApi.Application.Services.Models.Orders;
using AnytourApi.Constants.Controller;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Orders;
using AnytourApi.Dtos.ResponseDto;
using AnytourApi.Dtos.Shared;
using AnytourApi.WebApi.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnytourApi.WebApi.Controllers.Orders;

public class OrderController(IOrderService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetOrderDto,
    UpdateOrderDto,
    CreateOrderDto,
    IOrderService,
    Order,
    GetOrderDto>(CrudService, HttpContextAccessor)
{

    [HttpPost]
    [AllowAnonymous]
    public override async Task<IActionResult> Create([FromBody] CreateOrderDto dto, CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(
            new ThingsToValidateBase());
        if (errorEndPoint.IsError) return errorEndPoint.GetError();


        Guid? id = await CrudService.CreateAsync(dto, cancellationToken);

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (id == null) return BadRequest(ControllerStringConstants.SomethingWentWrongDuringCreateing);

        return Ok(new CreateResponseDto { Id = (Guid)id });
    }

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
