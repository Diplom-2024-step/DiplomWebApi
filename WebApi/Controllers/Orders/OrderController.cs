using AnytourApi.Application.Services.Models.Orders;
using AnytourApi.Constants.Controller;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Orders;
using AnytourApi.Dtos.ResponseDto;
using AnytourApi.Dtos.Shared;
using AnytourApi.Infrastructure.LinkFactories;
using AnytourApi.WebApi.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnytourApi.WebApi.Controllers.Orders;

public class OrderController(IOrderService CrudService, ILinkFactory linkFactory,  IHttpContextAccessor HttpContextAccessor) : CrudController<
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


        List<string> hotelPhotos = new List<string>();

        foreach (var link in model.Hotel.Urls)
        {
            hotelPhotos.Add(linkFactory.GetImageUrl(Request, link));
        }

        foreach (var item in model.Activities)
        {
            List<string> activitiesPhotos = new List<string>();

            foreach (var link in item.Urls)
            {
                activitiesPhotos.Add(linkFactory.GetImageUrl(Request, link));
            }
            item.Urls = activitiesPhotos;
        }


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

        foreach (var model in page.Models)
        {
            List<string> tourPhotos = new List<string>();

            List<string> hotelPhotos = new List<string>();



            foreach (var link in model.Hotel.Urls)
            {
                hotelPhotos.Add(linkFactory.GetImageUrl(Request, link));
            }

            foreach (var item in model.Activities)
            {
                List<string> activitiesPhotos = new List<string>();

                foreach (var link in item.Urls)
                {
                    activitiesPhotos.Add(linkFactory.GetImageUrl(Request, link));
                }
                item.Urls = activitiesPhotos;
            }

            model.Hotel.Urls = hotelPhotos;
        }


        return Ok(page
                   );
    }



}
