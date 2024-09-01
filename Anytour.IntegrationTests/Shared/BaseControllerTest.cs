using AnytourApi.Application.Services.Helpers;
using AnytourApi.Constants.Models.AppUsers;
using AnytourApi.Constants.Shared;
using AnytourApi.Domain.ForSort;
using AnytourApi.Domain.Models;
using AnytourApi.Dtos.Shared;
using AnytourApi.Infrastructure.JwtTokenFactories;
using AutoMapper;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;

namespace Anytour.IntegrationTests.shared;

public class BaseControllerTest : SharedIntegrationTest
{
    protected readonly IConfiguration Configuration = A.Fake<IConfiguration>();

    protected readonly CancellationToken CancellationToken = new CancellationToken();

    protected string JwtTokenForUserWithUserRole = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxMTI3NWJhOC1lMjYyLTQ0NWQtOTU5Yi0wZWQ4ZmUxYmVhODAiLCJ1bmlxdWVfbmFtZSI6InN0cmluZzEyMzIiLCJlbWFpbCI6InVzZXIyQGV4YW1wbGUuY29tIiwiQXNwTmV0LklkZW50aXR5LlNlY3VyaXR5U3RhbXAiOiJFRlJJQ1FEREQ1RzVTVkdITklUVE1CVzdDMkczUVhYQSIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcyOTYvYXBpIiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzI5NiIsIm5iZiI6MTcyNTE5NDE4MCwiZXhwIjoxMDM2NTE5NDE4MCwiaWF0IjoxNzI1MTk0MTgwfQ.9rJIaBscX-7S9S8W665voc2tStP2kZT1bX-oLTvDt9s";

    protected string JwtTokenForUserWithAdminRole = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxZTBhZTE5MC04ZjllLTRmZDktYWU2My0zYWU0ZjczMDEwMzciLCJ1bmlxdWVfbmFtZSI6InVzZXIiLCJlbWFpbCI6InVzZXIxQGV4YW1wbGUuY29tIiwiQXNwTmV0LklkZW50aXR5LlNlY3VyaXR5U3RhbXAiOiJQQzJBWFdTWDdCU1IyVURHUzVNQkQzTjQzS0xJQ0JJNyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcyOTYvYXBpIiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzI5NiIsIm5iZiI6MTcyNTE5Mzg2MCwiZXhwIjoxMDM2NTE5Mzg2MCwiaWF0IjoxNzI1MTkzODYwfQ.Vt6cCLLV6chFXa2YF51lwHmMIfg-f0DOrGdjv0TuxCQ";

    protected IMapper Mapper => new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfiles())).CreateMapper();

    protected User SampleAdminUser = new()
    {
        Email = "Admin@admin.com",
        UserName = "Admin",
        PasswordHash = "Password123!",

    };

    protected User SampleUsualUser = new()
    {
        Email = "user@user.com",
        UserName = "user",
        PasswordHash = "User123!",


    };

    public BaseControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
        A.CallTo(() => Configuration[AppSettingsStringConstants.JwtKey]).Returns("7DbP1lM5m0IiZWOWlaCSFApiHKfR0Zhb");
        A.CallTo(() => Configuration[AppSettingsStringConstants.JwtAudience]).Returns("Anytour.WebApi.Audience");
        A.CallTo(() => Configuration[AppSettingsStringConstants.JwtIssuer]).Returns("Anytour.WebApi");



    }

    protected FilterPaginationDto FilterPaginationDto => new()
    {
        Filters =
        [
                    ],
        Sorts =
        [
            new SortDto
            {
                Column = SharedStringConstants.IdName,
                SortOrder = SortOrder.Asc
            },
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
        var user = SampleAdminUser;

        //if (JwtTokenForUserWithAdminRole == null)
        //{
        //    var jwtTokenFactory = GetJwtTokenFactory(userManager);

        //    await userManager.CreateAsync(user, user.PasswordHash!);
        //    await userManager.AddToRoleAsync(user, UserStringConstants.AdminRole);


        //    JwtTokenForUserWithAdminRole = await jwtTokenFactory.GetJwtTokenAsync(user, Configuration);
        //}



        // CrudController_ mocks for HttpRequest and HttpContext
        var httpRequestMock = new Mock<HttpRequest>();
        var httpContextMock = new Mock<HttpContext>();

        httpRequestMock.Setup(req => req.Headers.Authorization).Returns(JwtTokenForUserWithAdminRole);
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
        //var jwtTokenFactory = GetJwtTokenFactory(userManager);
        //var user = SampleUsualUser;

        //if (JwtTokenForUserWithUserRole == null)
        //{

        //    await userManager.CreateAsync(user, user.PasswordHash!);
        //    await userManager.AddToRoleAsync(user, UserStringConstants.UserRole);


        //    JwtTokenForUserWithUserRole = await jwtTokenFactory.GetJwtTokenAsync(user, Configuration);
        //}

        // CrudController_ mocks for HttpRequest and HttpContext
        var httpRequestMock = new Mock<HttpRequest>();
        var httpContextMock = new Mock<HttpContext>();

        httpRequestMock.Setup(req => req.Headers.Authorization).Returns(JwtTokenForUserWithUserRole);

        // Setup the HttpContext mock to return the mocked HttpRequest
        httpContextMock.Setup(ctx => ctx.Request).Returns(httpRequestMock.Object);

        // Mock IHttpContextAccessor to return the mocked HttpContext
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        httpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContextMock.Object);

        return httpContextAccessorMock.Object;
    }

    protected IHttpContextAccessor GetHttpContextAccessForAnonymUser()
    {
        // CrudController_ mocks for HttpRequest and HttpContext
        var httpRequestMock = new Mock<HttpRequest>();
        var httpContextMock = new Mock<HttpContext>();

        httpRequestMock.Setup(req => req.Headers.Authorization).Returns("");

        // Setup the HttpContext mock to return the mocked HttpRequest
        httpContextMock.Setup(ctx => ctx.Request).Returns(httpRequestMock.Object);

        // Mock IHttpContextAccessor to return the mocked HttpContext
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        httpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContextMock.Object);

        return httpContextAccessorMock.Object;
    }
}
