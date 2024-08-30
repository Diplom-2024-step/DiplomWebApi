using AnytourApi.Constants.Models.AppUsers;
using AnytourApi.Constants.Shared;
using AnytourApi.Domain.ForSort;
using AnytourApi.Domain.Models;
using AnytourApi.Dtos.Shared;
using AnytourApi.Infrastructure.JwtTokenFactories;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;

namespace Anytour.IntegrationTests;

public class BaseControllerTest : SharedIntegrationTest
{
    protected readonly IConfiguration Configuration = A.Fake<IConfiguration>();

    protected readonly CancellationToken CancellationToken = new CancellationToken();

    protected User SampleUser = new()
    {
        Email = "test@gmail.com",
        UserName = "Test",
        PasswordHash = "Password123!"
    };

    public BaseControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
        A.CallTo(() => Configuration[AppSettingsStringConstants.JwtKey]).Returns("7DbP1lM5m0IiZWOWlaCSFApiHKfR0Zhb");

    }

    protected FilterPaginationDto FilterPaginationDto => new()
    {
        Filters =
        [
            [
                new FilterDto
                {
                    SearchTerm = "Test",
                    Column = SharedStringConstants.IdName,
                    IsStrict = true
                },
                new FilterDto
                {
                    SearchTerm = "Test1",
                    Column = SharedStringConstants.IdName,
                    IsStrict = true
                }
            ],
            [
                new FilterDto
                {
                    SearchTerm = "Test2",
                    Column = SharedStringConstants.IdName,
                    IsStrict = true
                }
            ]
        ],
        Sorts =
        [
            new SortDto
            {
                Column = SharedStringConstants.IdName,
                SortOrder = SortOrder.Asc
            },
            new SortDto
            {
                Column = SharedStringConstants.IdName,
                SortOrder = SortOrder.Desc
            }
        ],
        PageNumber = SharedNumberConstatnts.DefaultPageToStartWith,
        PageSize = SharedNumberConstatnts.DefaultItemsInOnePage
    };

    protected IJwtTokenFactory GetJwtTokenFactory(UserManager<User> userManager)
    {
        var options = new IdentityOptions(
        );
        var optionsAccessor = Options.Create(options);

        var userClaimsPrincipalFactory = new UserClaimsPrincipalFactory<User>(userManager, optionsAccessor);
        var jwtTokenFactory = new JwtTokenFactory(userClaimsPrincipalFactory);
        return jwtTokenFactory;
    }

    protected async Task<IHttpContextAccessor> GetHttpContextAccessForAdminUser(UserManager<User> userManager,
        RoleManager<IdentityRole<Guid>> roleManager)
    {
        // Generate JWT Token
        var jwtTokenFactory = GetJwtTokenFactory(userManager);
        var user = SampleUser;

        await userManager.CreateAsync(user, user.PasswordHash!);
        await userManager.AddToRoleAsync(user, UserStringConstants.AdminRole);


        var jwtToken = await jwtTokenFactory.GetJwtTokenAsync(user, Configuration);


        // CrudController_ mocks for HttpRequest and HttpContext
        var httpRequestMock = new Mock<HttpRequest>();
        var httpContextMock = new Mock<HttpContext>();

        httpRequestMock.Setup(req => req.Headers.Authorization).Returns(jwtToken);
        httpRequestMock.Setup(req => req.Scheme).Returns("https:7076://");
        httpRequestMock.Setup(req => req.Host).Returns(new HostString("api/v1"));
        httpRequestMock.Setup(req => req.Path).Returns(new PathString("/asdada/resdad/controller/GetGetAll"));

        // Setup the HttpContext mock to return the mocked HttpRequest
        httpContextMock.Setup(ctx => ctx.Request).Returns(httpRequestMock.Object);

        // Mock IHttpContextAccessor to return the mocked HttpContext
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        httpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContextMock.Object);

        return httpContextAccessorMock.Object;
    }

    protected async Task<IHttpContextAccessor> GetHttpContextAccessForUserUser(UserManager<User> userManager,
        RoleManager<IdentityRole<Guid>> roleManager)
    {
        // Generate JWT Token
        var jwtTokenFactory = GetJwtTokenFactory(userManager);
        var user = SampleUser;

        await userManager.CreateAsync(user, user.PasswordHash!);
        await userManager.AddToRoleAsync(user, UserStringConstants.UserRole);


        var jwtToken = await jwtTokenFactory.GetJwtTokenAsync(user, Configuration);

        // CrudController_ mocks for HttpRequest and HttpContext
        var httpRequestMock = new Mock<HttpRequest>();
        var httpContextMock = new Mock<HttpContext>();

        httpRequestMock.Setup(req => req.Headers.Authorization).Returns(jwtToken);

        // Setup the HttpContext mock to return the mocked HttpRequest
        httpContextMock.Setup(ctx => ctx.Request).Returns(httpRequestMock.Object);

        // Mock IHttpContextAccessor to return the mocked HttpContext
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        httpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContextMock.Object);

        return httpContextAccessorMock.Object;
    }
}
