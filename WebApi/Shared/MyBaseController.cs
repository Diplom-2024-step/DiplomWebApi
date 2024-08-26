using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Constants.Models.AppUsers;
using Dtos.Dto.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Shared.ErrorEndPoints;

namespace WebApi.Shared;

[Route("api/v1/[controller]")]
public abstract class MyBaseController( IHttpContextAccessor httpContextAccessor)
    : ControllerBase
{
    protected readonly IHttpContextAccessor HttpContextAccessor = httpContextAccessor;


   

    protected virtual ErrorEndPoint ValidateRequest(ThingsToValidateBase thingsToValidate)
    {
        ErrorEndPoint errorEndPoint = new();

        if (ModelState.IsValid) return errorEndPoint;
        errorEndPoint.BadRequestObjectResult = new BadRequestObjectResult(GetAllErrorsDuringValidation())
        { StatusCode = 422 };
        return errorEndPoint;
    }

    protected IDictionary<string, IEnumerable<string>> GetAllErrorsDuringValidation()
    {
        return ModelState.Where(kvp => kvp.Value?.Errors.Any() ?? false).ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage)
        );
    }

    protected record ThingsToValidateBase
    {


    }
}