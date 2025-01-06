using AnytourApi.WebApi.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnytourApi.WebApi.Controllers;

public class HealthController : MyBaseController
{
    public HealthController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
    }

    [HttpGet("check")]
    [AllowAnonymous]
    public IActionResult Get(CancellationToken cancellationToken) => Ok();

}
