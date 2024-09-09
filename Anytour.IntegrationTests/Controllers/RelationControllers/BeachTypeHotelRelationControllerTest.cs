using Anytour.IntegrationTests.shared;
using Anytour.IntegrationTests.Shared;
using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Relations.BeachTypeHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers.Hotels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Anytour.IntegrationTests.Controllers.RelationControllers;

public class BeachTypeHotelRelationControllerTest : BaseRelationControllerTest<
    BeachTypeHotel, BeachType, Hotel,
    BeachTypeHotelRelationController, IBeachTypeHotelRelationService, IBeachTypeHotelRelationRepository>
{
    public BeachTypeHotelRelationControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override Task<Guid> CreateFirstModel(IServiceProvider serviceProvider)
    {
        return SharedBeachTypeModels.CreateModelWithAllDependenciesAsync(serviceProvider, CancellationToken);
    }

    protected override Task<Guid> CreateSecondModel(IServiceProvider serviceProvider)
    {
        return SharedHotelModels.CreateModelWithAllDependenciesAsync(serviceProvider, CancellationToken);
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(AppDbContext);
        alternativeServices.AddSingleton(Mapper);

        SharedHotelModels.AddAllDependencies(alternativeServices);
        SharedBeachTypeModels.AddAllDependencies(alternativeServices);

        alternativeServices.AddScoped<IBeachTypeHotelRelationRepository, BeachTypeHotelRelationRepository>();

        alternativeServices.AddScoped<IBeachTypeHotelRelationService, BeachTypeHotelRelationService>();

        return alternativeServices;
    }

    protected override async Task<BeachTypeHotelRelationController> GetRelationController(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        return new BeachTypeHotelRelationController(
            serviceProvider.GetService<IBeachTypeHotelRelationService>(),
            await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext))
            );
    }
}
