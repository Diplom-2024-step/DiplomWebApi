﻿using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.EfPersistence.Data;
using AnytourApi.UnitTests;
using AnytourApi.Domain;
using FluentAssertions;
using AnytourApi.Domain.ForFilter;

namespace AnytourApi.UnitTests.Shared.Repositories;

public abstract class SharedRepositoryTest<TModel, TRepository>
    : SharedUnitTest
    where TModel : class, IModel
    where TRepository : ICrudRepository<TModel>
{
    protected abstract TModel GetSample();
    protected abstract TModel GetSampleForUpdate();
    protected abstract TRepository GetRepository(AppDbContext appDbContext);


    [Fact]
    public virtual async Task Repository_AddAsync_ReturnsModelAndId()
    {
        // Arrange
        var dbContext = GetDatabaseContext();
        var repository = GetRepository(dbContext);
        var sample = GetSample();

        // Act
        var result = await repository.AddAsync(sample, CancellationToken);

        // Assert
        result.Should().NotBeEmpty();
        var addedStatus = await repository.GetAsync(result, CancellationToken);
        addedStatus.Should().NotBeNull();
        addedStatus.Should().BeEquivalentTo(sample);
    }

    [Fact]
    public virtual async Task Repository_DeleteAsync_DeleteModel()
    {
        // Arrange
        var dbContext = GetDatabaseContext();
        var repository = GetRepository(dbContext);
        var model = GetSample();

        // Act
        var result = await repository.AddAsync(model, CancellationToken);

        await repository.DeleteAsync(result, CancellationToken);

        // Assert
        var deletedModel = await repository.GetAsync(result, CancellationToken);
        deletedModel.Should().BeNull();
    }

    [Fact]
    public virtual async Task Repository_GetAllAsync_ReturnsPage()
    {
        // Arrange
        var data = new List<TModel> { GetSample(), GetSample() };
        var dbContext = GetDatabaseContext();
        var repository = GetRepository(dbContext);
        foreach (var i in data) await repository.AddAsync(i, CancellationToken);
        var dto = new FilterPagination { PageNumber = 1, PageSize = 1 };

        // Act
        var result = await repository.GetAllAsync(dto, CancellationToken);

        // Assert
        Assert.Single(result.Models);

    }

    [Fact]
    public virtual async Task Repository_GetAllAsync_ReturnsAllModels()
    {
        // Arrange
        var data = new List<TModel> { GetSample(), GetSample() };
        var dbContext = GetDatabaseContext();
        var repository = GetRepository(dbContext);

        foreach (var i in data) await repository.AddAsync(i, CancellationToken);
        var ids = data.Select(m => m.Id).ToList();

        // Act
        var result = await repository.GetAllAsync(CancellationToken);

        // Assert
        Assert.Equal(ids.Count, result.Count);
    }


    [Fact]
    public virtual async Task Repository_GetAllModelsByIdsAsync_ReturnsModelsByIds()
    {
        // Arrange
        var data = new List<TModel> { GetSample(), GetSample() };
        var dbContext = GetDatabaseContext();

        var repository = GetRepository(dbContext);
        foreach (var i in data) await repository.AddAsync(i, CancellationToken);
        var ids = data.Select(m => m.Id).ToList();

        // Act
        var result = await repository.GetAllModelsByIdsAsync(ids, CancellationToken);

        // Assert
        Assert.Equal(ids.Count, result.Count);
    }

    [Fact]
    public virtual async Task Repository_GetAllModelsByIds_ReturnsModelsByIds()
    {
        // Arrange
        var data = new List<TModel> { GetSample(), GetSample() };
        var dbContext = GetDatabaseContext();

        var repository = GetRepository(dbContext);
        foreach (var i in data) await repository.AddAsync(i, CancellationToken);
        var ids = data.Select(m => m.Id).ToList();

        // Act
        var result = repository.GetAllModelsByIds(ids);

        // Assert
        Assert.Equal(ids.Count, result.Count);
    }




    [Fact]
    public virtual async Task Repository_GetAsync_ReturnsModel()
    {
        // Arrange
        var dbContext = GetDatabaseContext();
        var repository = GetRepository(dbContext);
        var sample = GetSample();
        var id = await repository.AddAsync(sample, CancellationToken);
        sample.Id = id;

        // Act
        var result = await repository.GetAsync(id, CancellationToken);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(sample);
    }

    [Fact]
    public virtual async Task Repository_Get_ReturnsModel()
    {
        // Arrange
        var dbContext = GetDatabaseContext();
        var repository = GetRepository(dbContext);
        var sample = GetSample();
        var id = await repository.AddAsync(sample, CancellationToken);
        sample.Id = id;

        // Act
        var result = repository.Get(id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(sample);
    }


    [Fact]
    public virtual async Task Repository_UpdateAsync_UpdateModel()
    {
        // Arrange
        var dbContext = GetDatabaseContext();
        var repository = GetRepository(dbContext);
        var sample = GetSample();
        var id = await repository.AddAsync(sample, CancellationToken);
        sample.Id = id;
        var updatedSample = GetSampleForUpdate();
        updatedSample.Id = id;

        // Act
        await repository.UpdateAsync(updatedSample, CancellationToken);

        var result = await repository.GetAsync(id, CancellationToken);

        if (typeof(TModel).GetProperty("UpdatedAt") is { } updateProperty)
            updateProperty.SetValue(updatedSample, updateProperty.GetValue(result));

        if (typeof(TModel).GetProperty("CreatedAt") is { } createProperty)
            createProperty.SetValue(updatedSample, createProperty.GetValue(result));

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(updatedSample);
    }
}