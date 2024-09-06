using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Shared.Relation;
using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.EfPersistence.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WebApiForHikka.WebApi.Shared.RelationController;
using Xunit;

namespace Anytour.IntegrationTests.Shared;

public abstract class BaseRelationControllerTest<
    TRelationModel, TFirstModel, TSecondModel,
    TRelationController, TRelationService, TRelationRepository
    > : BaseControllerTest
    where TRelationModel : RelationModel<TFirstModel, TSecondModel>
    where TFirstModel : class, IModel
    where TSecondModel : class, IModel
    where TRelationController : RelationController<TRelationModel, TFirstModel, TSecondModel, TRelationService>
    where TRelationService : IRelationService<TRelationModel, TFirstModel, TSecondModel>
    where TRelationRepository : IRelationRepository<TRelationModel, TFirstModel, TSecondModel>
    
{
    public BaseRelationControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected abstract IServiceCollection GetAllServices(IServiceCollection alternativeServices);


    protected abstract Task<TRelationController> GetRelationController(IServiceProvider serviceProvider, CancellationToken cancellationToken);

    protected abstract Task<Guid> CreateFirstModel(IServiceProvider serviceProvider);
    protected abstract Task<Guid> CreateSecondModel(IServiceProvider serviceProvider);

    [Fact]
    public virtual async Task CrudRelationController_Create_ReturnsOkObjectResult()
    {
        //Arrange
        var serviceCollection = new ServiceCollection();
        GetAllServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var controller = await GetRelationController(serviceProvider, CancellationToken);

        var firstId = await CreateFirstModel(serviceProvider);

        var secondId = await CreateSecondModel(serviceProvider);

        //Act

        var result = await controller.Create(firstId, secondId, CancellationToken) as OkObjectResult;

        //Assert

        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();

    }





    [Fact]
    public virtual async Task CrudRelationController_Delete_ReturnsOkObjectResult()
    {
        //Arrange
        var serviceCollection = new ServiceCollection();
        GetAllServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var controller = await GetRelationController(serviceProvider, CancellationToken);

        var firstId = await CreateFirstModel(serviceProvider);
        var secondId = await CreateSecondModel(serviceProvider);


        //Act

        await controller.Delete(firstId, secondId, CancellationToken);

        var result = await controller.Check(firstId, secondId, CancellationToken) as NotFoundResult;

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<NotFoundResult>();

    }

    [Fact]
    public virtual async Task CrudRelationController_Check_ReturnsOkObjectResult()
    {
        //Arrange
        var serviceCollection = new ServiceCollection();
        GetAllServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var controller = await GetRelationController(serviceProvider, CancellationToken);

        var firstId = await CreateFirstModel(serviceProvider);
        var secondId = await CreateSecondModel(serviceProvider);


        //Act

        await controller.Create(firstId, secondId, CancellationToken);

        var result = await controller.Check(firstId, secondId, CancellationToken) as OkResult;

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkResult>();

    }

    [Fact]
    public virtual async Task CrudRelationController_Check_ReturnsNotFoundObjectResult()
    {
        //Arrange
        var serviceCollection = new ServiceCollection();
        GetAllServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var controller = await GetRelationController(serviceProvider, CancellationToken);

        //Act

        var result = await controller.Check(Guid.NewGuid(), Guid.NewGuid(), CancellationToken) as NotFoundResult;

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<NotFoundResult>();
    }


}
