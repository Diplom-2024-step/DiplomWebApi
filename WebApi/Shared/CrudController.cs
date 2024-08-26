using Application.Services.Shared;
using AutoMapper;
using Constants.Controller;
using Domain.Models.Shared;
using Dtos.ResponseDto;
using Dtos.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Shared.ErrorEndPoints;

namespace WebApi.Shared;

// ! Don't change TModel position
[Authorize(Policy = ControllerStringConstants.CanAccessOnlyAdmin)]
public abstract class CrudController<TGetDto, TUpdateDto, TCreateDto, TIService, TModel, TGetLightDto>(
    TIService crudService,
    IHttpContextAccessor httpContextAccessor)
    : MyBaseController(httpContextAccessor),
        ICrudController<TUpdateDto, TCreateDto>
    where TModel : class, IModel
    where TUpdateDto : ModelDto
    where TGetDto : ModelDto
    where TIService : ICrudService<TGetDto, TCreateDto, TUpdateDto, TModel, TGetLightDto>
{
    protected TIService CrudService = crudService;


    [HttpPost]
    public virtual async Task<IActionResult> Create([FromBody] TCreateDto dto, CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(
            new ThingsToValidateBase());
        if (errorEndPoint.IsError) return errorEndPoint.GetError();


        Guid? id = await CrudService.CreateAsync(dto, cancellationToken);

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (id == null) return BadRequest(ControllerStringConstants.SomethingWentWrongDuringCreateing);

        return Ok(new CreateResponseDto { Id = (Guid)id });
    }


    [HttpDelete("{id:Guid}")]
    public virtual async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(
            new ThingsToValidateBase());
        if (errorEndPoint.IsError) return errorEndPoint.GetError();


        await CrudService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }


    [HttpGet("{id:Guid}")]
    public virtual async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
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
    public virtual async Task<IActionResult> GetAll([FromBody] FilterPaginationDto paginationDto,
        CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(
            new ThingsToValidateBase());

        CkeckIfColumnsAreInModel(paginationDto, errorEndPoint);

        if (errorEndPoint.IsError) return errorEndPoint.GetError();

        var page = await CrudService.GetAllAsync(paginationDto, cancellationToken);

        return Ok(page
                   );
    }


    [HttpPut]
    public virtual async Task<IActionResult> Put([FromBody] TUpdateDto dto, CancellationToken cancellationToken)
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

    protected virtual ErrorEndPoint ValidateRequestForUpdateEndPoint(ThingsToValidateForUpdate thingsToValidate)
    {
        var errorEndPoint = ValidateRequest(thingsToValidate);
        if (errorEndPoint.IsError) return errorEndPoint;

        var model = CrudService.Get(thingsToValidate.UpdateDto.Id);
        if (model != null) return errorEndPoint;

        errorEndPoint.BadRequestObjectResult =
            new BadRequestObjectResult(ControllerStringConstants.ModelWithThisIdDoesntExistForUpdateEndPoint)
            { StatusCode = 404 };
        return errorEndPoint;
    }


    protected void CkeckIfColumnsAreInModel(FilterPaginationDto filterDtos, ErrorEndPoint error)
    {
        var columsOfModels = typeof(TGetDto).GetProperties();

        var listOfPropertiesNames = new List<string>();


        foreach (var i in columsOfModels)
        {
            listOfPropertiesNames.Add(i.Name);
        }


        foreach (var item in filterDtos.Sorts)
        {
            if (!listOfPropertiesNames.Contains(item.Column))
            {
                error.BadRequestObjectResult = new BadRequestObjectResult($"Column with this name {item.Column} doesn't exist");
                return;
            }

        }

        foreach (var column in filterDtos.Filters)
        {
            foreach (var item in column)
            {
                if (!listOfPropertiesNames.Contains(item.Column))
                {
                    error.BadRequestObjectResult = new BadRequestObjectResult($"Column with this name {item.Column} doesn't exist");
                    return;
                }

            }
        }

    }



    protected record ThingsToValidateForUpdate : ThingsToValidateBase
    {
        public required TUpdateDto UpdateDto { get; init; }
    }
}