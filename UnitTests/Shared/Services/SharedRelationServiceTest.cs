using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Application.Repositories.Shared.Relation;
using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.EfPersistence.Data;
using FluentAssertions;

namespace AnytourApi.UnitTests.Shared.Services;

public abstract class SharedRelationServiceTest<
    TRelationModel, TRelationService,
    TFirstModel, TSecondModel,
    IFirstRepository, ISecondRepository
    > : SharedUnitTest
where TRelationModel : RelationModel<TFirstModel, TSecondModel>
    where TRelationService : IRelationService<TRelationModel, TFirstModel, TSecondModel>
    where IFirstRepository : ICrudRepository<TFirstModel>
    where ISecondRepository : ICrudRepository<TSecondModel>
    where TFirstModel : class, IModel
    where TSecondModel : class, IModel
{
    public abstract IFirstRepository GetFirstRepository(AppDbContext appDbContext);

    public abstract ISecondRepository GetSecondRepository(AppDbContext appDbContext);

    public abstract TRelationService GetRelationService(AppDbContext appDbContext);

    public abstract TFirstModel GetFirstModel();

    public abstract TSecondModel GetSecondModel();

    public abstract TRelationModel GetRelationModel(Guid firstId, Guid secondId);



    [Fact]
    public virtual async Task RelationService_DeleteAsync_DeleteModel()
    {
        // Arrange
        var dbContext = GetDatabaseContext();
        var firstRepository = GetFirstRepository(dbContext);
        var secondRepository = GetSecondRepository(dbContext);
        var relationRepository = GetRelationService(dbContext);
        var firstModelSample = GetFirstModel();
        var secondModelSample = GetSecondModel();

        // Act
        var firstId = await firstRepository.AddAsync(firstModelSample, CancellationToken);
        var secondId = await secondRepository.AddAsync(secondModelSample, CancellationToken);
        await relationRepository.CreateAsync(GetRelationModel(firstId, secondId), CancellationToken);

        await relationRepository.DeleteAsync(firstId, secondId, CancellationToken);

        // Assert
        var deletedModel = await relationRepository.GetAsync(firstId, secondId, CancellationToken);
        deletedModel.Should().BeNull();
    }

    [Fact]
    public virtual async Task RelationService_GetAsync_ReturnsModel()
    {
        // Arrange
        var dbContext = GetDatabaseContext();
        var firstRepository = GetFirstRepository(dbContext);
        var secondRepository = GetSecondRepository(dbContext);
        var relationRepository = GetRelationService(dbContext);
        var firstModelSample = GetFirstModel();
        var secondModelSample = GetSecondModel();

        // Act
        var firstId = await firstRepository.AddAsync(firstModelSample, CancellationToken);
        var secondId = await secondRepository.AddAsync(secondModelSample, CancellationToken);
        await relationRepository.CreateAsync(GetRelationModel(firstId, secondId), CancellationToken);
        var addedModel = await relationRepository.GetAsync(firstId, secondId, CancellationToken);

        // Assert
        addedModel.Should().NotBeNull();
        addedModel.FirstId.Should().Be(firstId);
        addedModel.SecondId.Should().Be(secondId);
    }

    [Fact]
    public virtual async Task RelationService_CheckIfModelsWithThisIdsExist_ReturnsTrue()
    {
        // Arrange
        var dbContext = GetDatabaseContext();
        var firstRepository = GetFirstRepository(dbContext);
        var secondRepository = GetSecondRepository(dbContext);
        var relationRepository = GetRelationService(dbContext);
        var firstModelSample = GetFirstModel();
        var secondModelSample = GetSecondModel();
        var firstId = await firstRepository.AddAsync(firstModelSample, CancellationToken);
        var secondId = await secondRepository.AddAsync(secondModelSample, CancellationToken);
        var addedModel = await relationRepository.GetAsync(firstId, secondId, CancellationToken);

        // Act
        var result = relationRepository.CheckIfModelsWithThisIdsExist(firstId, secondId);

        // Assert
        result.Should().BeTrue();
    }
}