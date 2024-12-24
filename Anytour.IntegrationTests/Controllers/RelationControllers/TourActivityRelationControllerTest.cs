using Anytour.IntegrationTests.shared;
using Anytour.IntegrationTests.Shared;
using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Relations.TourActivities;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers.Tours;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.RelationControllers;

class TourActivityRelationControllerTest : BaseRelationControllerTest<
TourActivity, Tour, Activity,
TourActivityRelationController, ITourActivityRelationService, ITourActivityRelationRepository>
{
    public TourActivityRelationControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override Task<Guid> CreateFirstModel(IServiceProvider serviceProvider)
    {
        return SharedTourModels.CreateModelWithAllDependenciesAsync(serviceProvider, CancellationToken);
    }

    protected override Task<Guid> CreateSecondModel(IServiceProvider serviceProvider)
    {
        return SharedActivityModels.CreateModelWithAllDependenciesAsync(serviceProvider, CancellationToken);
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(AppDbContext);
        alternativeServices.AddSingleton(Mapper);
     

        SharedActivityModels.AddAllDependencies(alternativeServices);
        SharedTourModels.AddAllDependencies(alternativeServices);
        SharedUserModels.AddAllDependencies(alternativeServices);

        alternativeServices.AddScoped<ITourActivityRelationRepository, TourActivityRelationRepository>();

        alternativeServices.AddScoped<ITourActivityRelationService, TourActivityRelationService>();

        return alternativeServices;
    }

    protected override async Task<TourActivityRelationController> GetRelationController(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        return new TourActivityRelationController(
            serviceProvider.GetService<ITourActivityRelationService>(),
            await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext))
            );
    }
}
