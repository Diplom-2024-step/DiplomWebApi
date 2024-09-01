using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Services.Users;
using AnytourApi.Constants.Models.AppUsers;
using AnytourApi.Domain.Models;
using AnytourApi.Dtos.Dto.Users;
using AnytourApi.Dtos.ResponseDto;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace WebApiForHikka.Test.Controllers.Users;

public class UserControllerTest : BaseControllerTest
{
    public UserControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected void GetAllServicesInServiceCollection(AppDbContext dbContext, IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(dbContext);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);


    }

    protected IUserService GetUserService(AppDbContext dbContext, UserManager<User> userManager)
    {
        var userRepository = new UserRepository(dbContext, userManager);

        return new UserService(userRepository, Mapper);
    }


    protected async Task<UserController> GetUserControllerForAdmin()
    {
        var serviceCollection = new ServiceCollection();

        var dbContext = AppDbContext;

        GetAllServicesInServiceCollection(dbContext, serviceCollection);

        var services = serviceCollection.BuildServiceProvider();

        var roleManager = GetRoleManager(dbContext);

        var userManager = GetUserManager(dbContext);


        var controller = new UserController(GetUserService(dbContext, userManager),
            GetJwtTokenFactory(userManager),
            Configuration,
            GetRoleManager(dbContext),
            await GetHttpContextAccessForAdminUser(userManager, roleManager)
        );

        return controller;
    }

    protected async Task<UserController> GetUserControllerForUser()
    {
        var serviceCollection = new ServiceCollection();

        var dbContext = AppDbContext;

        GetAllServicesInServiceCollection(dbContext, serviceCollection);

        var services = serviceCollection.BuildServiceProvider();

        var roleManager = GetRoleManager(dbContext);

        var userManager = GetUserManager(dbContext);

        var controller = new UserController(GetUserService(dbContext, userManager),
            GetJwtTokenFactory(userManager),
            Configuration,
            GetRoleManager(dbContext),
            await GetHttpContextAccessForUserUser(userManager, roleManager)
        );

        return controller;
    }

    protected UserController GetUserControllerForAnonymus()
    {
        var serviceCollection = new ServiceCollection();

        var dbContext = AppDbContext;

        GetAllServicesInServiceCollection(dbContext, serviceCollection);

        var services = serviceCollection.BuildServiceProvider();

        var userManager = GetUserManager(dbContext);


        var controller = new UserController(GetUserService(dbContext, userManager),
            GetJwtTokenFactory(userManager),
            Configuration,
            GetRoleManager(dbContext),
            GetHttpContextAccessForAnonymUser()
        );

        return controller;
    }


    [Fact]
    public async Task Register_ValidModel_ReturnsOk()
    {
        // Arrange
        var userRegistrationDto = SharedUserModels.GetUserRegistrationDtoForAdminSample();


        var controller = GetUserControllerForAnonymus();
        // Act
        var result = await controller.Create(userRegistrationDto, CancellationToken);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<RegistratedResponseUserDto>(okResult.Value);
        Assert.Equal(UserStringConstants.MessageUserRegistrated, response.Message);
    }


    [Fact]
    public async Task Get_ValidId_ReturnsOkWithUser()
    {
        // Arrange
        var controller = await GetUserControllerForAdmin();
        var user = SharedUserModels.GetUserRegistrationDtoForAdminSample();

        user.UserName = "tesf231231";
        user.Email = "dddaq1@gmail.com";

        // Act
        var guestCreate = await controller.Create(user, CancellationToken) as OkObjectResult;
        var createUserId = (guestCreate!.Value as RegistratedResponseUserDto)!.Id;
        var result = await controller.Get(createUserId, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedUser = Assert.IsType<GetUserDto>(okResult.Value);
        Assert.Equal(createUserId, returnedUser.Id);
    }

    [Fact]
    public async Task Put_ValidModel_ReturnsNoContentAndUpdatesUser()
    {
        // Arrange
        var controller = await GetUserControllerForAdmin();
        var createUserDto = SharedUserModels.GetUserRegistrationDtoForAdminSample();

        createUserDto.UserName = "Adminjovqnib";
        createUserDto.Email = "1231test12eda@gmail.com";

        var createResult = await controller.Create(createUserDto, CancellationToken.None);

        var okCreateResult = Assert.IsType<OkObjectResult>(createResult);
        var registeredUser = Assert.IsType<RegistratedResponseUserDto>(okCreateResult.Value);

        var createdUserId = registeredUser.Id;


        var updateUserDto = SharedUserModels.GetSampleUpdateDto();
        updateUserDto.Id = createdUserId;


        // Act
        var putResult = await controller.Put(updateUserDto, CancellationToken.None);

        // Assert
        Assert.IsType<NoContentResult>(putResult);

        var getResult = await controller.Get(createdUserId, CancellationToken.None);
        var okGetResult = Assert.IsType<OkObjectResult>(getResult);
        var updatedUser = Assert.IsType<GetUserDto>(okGetResult.Value);

        Assert.Equal(updateUserDto.UserName, updatedUser.UserName);
        Assert.Equal(updateUserDto.Email, updatedUser.Email);
    }


    [Fact]
    public async Task Delete_ValidId_ReturnsNoContentAndRemovesUser()
    {
        // Arrange
        var controller = await GetUserControllerForAdmin();
        var userDto = SharedUserModels.GetUserRegistrationDtoForAdminSample();

        userDto.UserName = "tefaf11";
        userDto.Email = "test12eda@gmail.com";

        // Create a user
        var createResult = await controller.Create(userDto, CancellationToken.None) as OkObjectResult;
        Assert.NotNull(createResult);

        var registeredUser = Assert.IsType<RegistratedResponseUserDto>(createResult.Value);
        var createdUserId = registeredUser.Id;

        // Act
        var deleteResult = await controller.Delete(createdUserId, CancellationToken.None);

        // Assert
        Assert.IsType<NoContentResult>(deleteResult);

        var getDeletedResult = await controller.Get(createdUserId, CancellationToken.None) as NotFoundResult;
        Assert.IsType<NotFoundResult>(getDeletedResult);
    }

    [Fact] async Task GetAll_ValidData_ReturnsUsers() 
    {
        var controller = await GetUserControllerForAdmin();
        var userDto = SharedUserModels.GetUserRegistrationDtoForAdminSample();

        userDto.UserName = "tefaf1";
        userDto.Email = "test1eda@gmail.com";

        var userDto2 = SharedUserModels.GetUserRegistrationDtoForAdminSample();

        userDto2.UserName = "t2efaf1";
        userDto2.Email = "test31eda@gmail.com";


        // Create user2
        var createResult = await controller.Create(userDto, CancellationToken.None) as OkObjectResult;
        Assert.NotNull(createResult);

        var createResult2 = await controller.Create(userDto2, CancellationToken.None) as OkObjectResult;
        Assert.NotNull(createResult);

        //Act

        var page = controller.GetAll(FilterPaginationDto, CancellationToken);

        Assert.NotNull(page);


    }
}