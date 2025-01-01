using AnytourApi.Application.Services.Users;
using AnytourApi.Constants.Controller;
using AnytourApi.Constants.Models.AppUsers;
using AnytourApi.Dtos.Dto.Users;
using AnytourApi.Dtos.ResponseDto;
using AnytourApi.Dtos.Shared;
using AnytourApi.Infrastructure.JwtTokenFactories;
using AnytourApi.WebApi.Shared;
using AutoMapper;
using AnytourApi.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using AnytourApi.Infrastructure.EmailServer;

namespace AnytourApi.WebApi.Controllers;

[Authorize(ControllerStringConstants.CanAccessOnlyAdmin)]
public class UserController(
    IUserService userService,
    IEmailService emailService,
    IJwtTokenFactory jwtTokenFactory,
    IConfiguration configuration,
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

        // Prepare email content
        string subject = "Welcome to Anytour!";
        string htmlBody = $"Dear {model.UserName},<br><br>Welcome to Anytour! Your registration is complete.<br><br>Your username: {model.Email}<br><br>Best regards,<br>Anytour Team";
        string plainTextBody = $"Dear {model.UserName},\n\nWelcome to Anytour! Your registration is complete.\n\nYour username: {model.Email}\n\nBest regards,\nAnytour Team";

        //// Send welcome email
        //try
        //{
        //    await _emailService.SendEmailAsync(new EmailRequest
        //    {
        //        FromName = "Anytour Support",
        //        To = new List<string> { model.Email },
        //        Subject = subject,
        //        Html = htmlBody,
        //        PlainText = plainTextBody
        //    });

        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}


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
        if (user == null) return Unauthorized();

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
        if (user == null) return Unauthorized();

        var tokenString = await _jwtTokenFactory.GetJwtTokenAsync(user, _configuration);

        return Ok(new LoginResponseUserDto { Token = tokenString! });
    }
}