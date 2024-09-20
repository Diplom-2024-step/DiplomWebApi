using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Application.Services.Helpers;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.ForFilter;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.Dtos.Shared;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Shared.Services;

public abstract class SharedServiceTest<TGetDto,
    TCreateDto,
    TUpdateDto,
    TModel,
    TGetLightDto,
    TRepository,
    TService> : SharedUnitTest

    where TModel : class, IModel
    where TRepository : ICrudRepository<TModel>
    where TGetDto : ModelDto
    where TUpdateDto : ModelDto
    where TService : ICrudService<TGetDto, TCreateDto, TUpdateDto, TModel, TGetLightDto>
{
    protected abstract IServiceCollection GetAllServices(IServiceCollection alternativeServices);
    protected abstract TService GetService(IServiceCollection alternativeServices);

    protected abstract TCreateDto GetCreateDtoSample();
    protected abstract TUpdateDto GetUpdateDtoSample();

    protected IMapper Mapper => new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfiles())).CreateMapper();


    [Fact]
    public virtual async Task Service_CreateAsync_ReturnsModelAndId()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();
        GetAllServices(serviceCollection);
        var service = GetService(serviceCollection);
        var sample = GetCreateDtoSample();

        // Act
        var result = await service.CreateAsync(sample, CancellationToken);

        // Assert
        result.Should().NotBeEmpty();
        var addedStatus = await service.GetAsync(result, CancellationToken);
        addedStatus.Should().NotBeNull();
        addedStatus.Should().BeOfType<TGetDto?>();
    }

    [Fact]
    public virtual async Task Service_DeleteAsync_DeleteModel()
    {
        // Arrange
         var serviceCollection = new ServiceCollection();
        GetAllServices(serviceCollection);
        var service = GetService(serviceCollection);
        var sample = GetCreateDtoSample();

        // Act
        var result = await service.CreateAsync(sample, CancellationToken);

        await service.DeleteAsync(result, CancellationToken);

        // Assert
        var deletedModel = await service.GetAsync(result, CancellationToken);
        deletedModel.Should().BeNull();
    }

    [Fact]
    public virtual async Task Service_GetAllAsync_ReturnsPage()
    {
        // Arrange
        var data = new List<TCreateDto> { GetCreateDtoSample(), GetCreateDtoSample() };
        var serviceCollection = new ServiceCollection();
        GetAllServices(serviceCollection);
        var service = GetService(serviceCollection);
        var sample = GetCreateDtoSample();
        foreach (var i in data) await service.CreateAsync(i, CancellationToken);
        var dto = new FilterPaginationDto { PageNumber = 1, PageSize = 1 };

        // Act
        var result = await service.GetAllAsync(dto, CancellationToken);

        // Assert
        Assert.Single(result.Models);
        result.HowManyPages.Should().Be(2);
        result.Total.Should().Be(2);
        result.IsNextPage.Should().Be(true);
        result.IsPreviosPage.Should().Be(false);
    }


    [Fact]
    public async Task Service_GetAllModelsByIdsAsync_ReturnsModelsByIds()
    {
        // Arrange
        var data = new List<TCreateDto> { GetCreateDtoSample(), GetCreateDtoSample() };
        var serviceCollection = new ServiceCollection();
        GetAllServices(serviceCollection);

        var service = GetService(serviceCollection);
        var sample = GetCreateDtoSample();
        List<Guid> ids = new List<Guid>();
        foreach (var i in data) ids.Add(await service.CreateAsync(i, CancellationToken));

        // Act
        var result = await service.GetAllModelsByIdsAsync(ids, CancellationToken);

        // Assert
        Assert.Equal(ids.Count, result.Count());
    }

    [Fact]
    public virtual async Task Service_GetAsync_ReturnsModel()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();
        GetAllServices(serviceCollection);
        var service = GetService(serviceCollection);
        var sample = GetCreateDtoSample();
        var id = await service.CreateAsync(sample, CancellationToken);

        // Act
        var result = await service.GetAsync(id, CancellationToken);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<TGetDto?>();
    }

    [Fact]
    public virtual async Task Service_UpdateAsync_UpdateModel()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();
        GetAllServices(serviceCollection);
        var service = GetService(serviceCollection);
        var sample = GetCreateDtoSample();
        var id = await service.CreateAsync(sample, CancellationToken);
        var updatedSample = GetUpdateDtoSample();
        updatedSample.Id = id;

        // Act
        await service.UpdateAsync(updatedSample, CancellationToken);

        var result = await service.GetAsync(id, CancellationToken);

  
        // Assert
        result.Should().NotBeNull();
        CompareFieldsWithTheSameNames(result!, updatedSample).Should().Be(true);
    }

}
