using AnytourApi.Application.Services.Users;
using AnytourApi.Constants.Controller;
using AnytourApi.Constants.Models.AppUsers;
using AnytourApi.Dtos.Dto.Users;
using AnytourApi.Dtos.ResponseDto;
using AnytourApi.Dtos.Shared;
using AnytourApi.Infrastructure.JwtTokenFactories;
using AnytourApi.WebApi.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using AnytourApi.Infrastructure.EmailServer;
using Mailjet.Client;
using Mailjet.Client.Resources;
using System;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using AnytourApi.Infrastructure.LinkFactories;

namespace AnytourApi.WebApi.Controllers;

[Authorize(ControllerStringConstants.CanAccessOnlyAdmin)]
public class UserController(
    IUserService userService,
    IEmailService emailService,
    IJwtTokenFactory jwtTokenFactory,
    IConfiguration configuration,
    ILinkFactory linkFactory,
    RoleManager<IdentityRole<Guid>> roleManager,
    IHttpContextAccessor httpContextAccessor
)
    : MyBaseController(httpContextAccessor),
        ICrudController<UpdateUserDto, UserRegistrationDto>
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IJwtTokenFactory _jwtTokenFactory = jwtTokenFactory;
    private readonly IUserService _userService = userService;
    private readonly IEmailService _emailService = emailService;
    private readonly ILinkFactory _linkFactory = linkFactory;



    [AllowAnonymous]
    [HttpPost("RegistrationWithEmail")]
    [SwaggerResponse(StatusCodes.Status200OK, "User registered", typeof(RegistratedResponseUserDto))]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
       typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> CreateWithEmail([FromBody] UserRegistrationDto model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return UnprocessableEntity(GetAllErrorsDuringValidation());



        var role = await roleManager.FindByNameAsync(model.Role);


        var token = await _userService.RegisterUserWithCodeAsync(model, cancellationToken);

        var link = _linkFactory.GetConfirmingLink(Request, model.Email, token!);



        await _emailService.SendConfirmingEmail(model.Email, model.UserName, link);

        if (token == null) return NotFound(UserStringConstants.MessageUserIsntRegistrated);


        return Ok();
    }


    [AllowAnonymous]
    [HttpGet("Confirm")]
    [SwaggerResponse(StatusCodes.Status200OK, "Email confirmed")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Email wasn't confirmed")]
    public async Task<IActionResult> Confirm([FromQuery] string email, [FromQuery] string code, CancellationToken cancellationToken) 
    {
        var result = await _userService.ConfirmEmailAsync(email, code, cancellationToken);

        if (!result) return NotFound("Email wasn't confirmed");

        return Ok("Email confirmed");
    }

    [AllowAnonymous]
    [HttpPost("Registration")]
    [SwaggerResponse(StatusCodes.Status200OK, "User registered", typeof(RegistratedResponseUserDto))]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
        typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> Create([FromBody] UserRegistrationDto model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return UnprocessableEntity(GetAllErrorsDuringValidation());

        var role = await roleManager.FindByNameAsync(model.Role);


        var id = await _userService.RegisterUserAsync(model, cancellationToken);

        if (id == null) return NotFound(UserStringConstants.MessageUserIsntRegistrated);

        var user = await _userService.GetRawAsync((Guid)id, cancellationToken);


        var tokenString = await _jwtTokenFactory.GetJwtTokenAsync(user, _configuration);

        return Ok(new RegistratedResponseUserDto
        {
            Message = UserStringConstants.MessageUserRegistrated,
            JwtToken = tokenString!,
            Id = (Guid)id
        }
        );
    }


    [HttpPost("GetAll")]
    [SwaggerResponse(StatusCodes.Status200OK, "Return all users")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
        typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> GetAll([FromBody] FilterPaginationDto paginationDto,
        CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(new ThingsToValidateBase());
        if (errorEndPoint.IsError) return errorEndPoint.GetError();


        var returnPageDto = await _userService.GetAllAsync(paginationDto, cancellationToken);



        return Ok(
            returnPageDto
        );
    }


    [AllowAnonymous]
    [HttpGet("{id:Guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Return user by id", typeof(GetUserDto))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "User not found")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
        typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(new ThingsToValidateBase());
        if (errorEndPoint.IsError) return errorEndPoint.GetError();

        var user = await _userService.GetAsync(id, cancellationToken);

        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [AllowAnonymous]
    [HttpPut("")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "User updated")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "User not found", typeof(string))]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
        typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> Put([FromBody] UpdateUserDto dto, CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(
            new ThingsToValidateBase());
        if (errorEndPoint.IsError) return errorEndPoint.GetError();


        var getUser = await _userService.GetAsync(dto.Id, cancellationToken);
        if (getUser == null) return NotFound($"user with {dto.Id} doesn't exist");



        await _userService.UpdateAsync(dto, cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:Guid}")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "User deleted")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
        typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(new ThingsToValidateBase());
        if (errorEndPoint.IsError) return errorEndPoint.GetError();

        await _userService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }


    [AllowAnonymous]
    [HttpPost("Login")]
    [SwaggerResponse(StatusCodes.Status200OK, "User logged in", typeof(LoginResponseUserDto))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
        typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> Login([FromBody] UserLoginDto model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return UnprocessableEntity(GetAllErrorsDuringValidation());

        var user = await _userService.AuthenticateUserAsync(model.Email, model.Password, cancellationToken);
        if (user == null || user.EmailConfirmed == false) return Unauthorized();

        var tokenString = await _jwtTokenFactory.GetJwtTokenAsync(user, _configuration);

        return Ok(new LoginResponseUserDto { Token = tokenString! });
    }

    [AllowAnonymous]
    [HttpPost("LoginAdmin")]
    [SwaggerResponse(StatusCodes.Status200OK, "User logged in", typeof(LoginResponseUserDto))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
        typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> LoginAdmin([FromBody] UserLoginDto model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return UnprocessableEntity(GetAllErrorsDuringValidation());

        var user = await _userService.AuthenticateUserWithAdminRoleAsync(model.Email, model.Password, cancellationToken);

        if (user == null || user.EmailConfirmed == false) return Unauthorized();

        var tokenString = await _jwtTokenFactory.GetJwtTokenAsync(user, _configuration);

        return Ok(new LoginResponseUserDto { Token = tokenString! });
    }

   
    //[AllowAnonymous]
    //[HttpPost("SendMail")]
    //public async Task<IActionResult> SendMail(CancellationToken cancellationToken) 
    //{
    //    MailjetClient client = new MailjetClient("53862af37825f8fe3f89f5087287aeed", "85e639820e478b17764d42a443bb7730")
    //    {
    //        BaseAdress = "https://api.mailjet.com/v3"
    //    };

    //    MailjetRequest request = new MailjetRequest
    //    {
    //        Resource = Send.Resource,
    //    }
    //        .Property(Send.FromEmail, "water.resistant.5atm@gmail.com")
    //        .Property(Send.FromName, "Expedia")
    //        .Property(Send.Recipients, new JArray {
    //             new JObject {
    //                 {"Email", "dentef767@gmail.com"},
    //                    {"Name", "Passenger 1"}

    //             }
    //        })
    //        .Property(Send.Subject, "Your email flight plan!")
    //        .Property(Send.TextPart, "Dear passenger, welcome to Mailjet! May the delivery force be with you!")
    //        .Property(Send.HtmlPart, "<h3>Dear passenger, welcome to Mailjet!</h3><br />May the delivery force be with you!");
    //    MailjetResponse response = await client.PostAsync(request);
    //    if (response.IsSuccessStatusCode)
    //    {
    //        Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
    //        Console.WriteLine(response.GetData());
    //    }
    //    else
    //    {
    //        Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
    //        Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
    //        Console.WriteLine(response.GetData());
    //        Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
    //    }
    //    if (response.StatusCode == 200)
    //    {
    //        return Ok($"Email sent successfully {response.Content}");
    //    }
    //    else
    //    {
    //        return BadRequest($"Failed to send email. Status code: {response.GetErrorInfo()} {response.StatusCode} {response.Content}");
    //    }
    //}
}