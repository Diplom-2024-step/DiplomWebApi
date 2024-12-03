using AnytourApi.Application.Services.Models.Hotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Hotels;
using AnytourApi.Dtos.Shared;
using AnytourApi.Infrastructure.LinkFactories;
using AnytourApi.WebApi.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnytourApi.WebApi.Controllers.Hotels;

public class HotelController(IHotelService CrudService, ILinkFactory linkFactory,  IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetHotelDto,
    UpdateHotelDto,
    CreateHotelDto,
    IHotelService,
    Hotel,
    GetHotelDto>(CrudService, HttpContextAccessor)
{
    [AllowAnonymous]
    [HttpGet("{id:Guid}")]
    public override async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(
            new ThingsToValidateBase());
        if (errorEndPoint.IsError) return errorEndPoint.GetError();


        var model = await CrudService.GetAsync(id, cancellationToken);
        if (model is null)
            return NotFound();

        List<string> links = new List<string>();

        foreach (var link in model.Urls)
        {
            links.Add(linkFactory.GetImageUrl(Request, link));
        }
        model.Urls = links;

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

            List<string> links = new List<string>();

            foreach (var link in model.Urls)
            {
                links.Add(linkFactory.GetImageUrl(Request, link));
            }
            model.Urls = links;
        }

        return Ok(page
                   );
    }


}
