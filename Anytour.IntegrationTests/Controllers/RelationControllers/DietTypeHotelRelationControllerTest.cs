using Anytour.IntegrationTests.shared;
using Anytour.IntegrationTests.Shared;
using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Relations.DietTypeHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers.Hotels;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.RelationControllers;

public class DietTypeHotelRelationControllerTest : BaseRelationControllerTest<
    DietTypeHotel, DietType, Hotel,
    DietTypeHotelRelationController, IDietTypeHotelRelationService, IDietTypeHotelRelationRepository>
{
    public DietTypeHotelRelationControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override Task<Guid> CreateFirstModel(IServiceProvider serviceProvider)
    {
        return SharedDietTypeModels.CreateModelWithAllDependenciesAsync(serviceProvider, CancellationToken);
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
        SharedDietTypeModels.AddAllDependencies(alternativeServices);

        alternativeServices.AddScoped<IDietTypeHotelRelationRepository, DietTypeHotelRelationRepository>();

        alternativeServices.AddScoped<IDietTypeHotelRelationService, DietTypeHotelRelationService>();

        return alternativeServices;
    }

    protected override async Task<DietTypeHotelRelationController> GetRelationController(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        return new DietTypeHotelRelationController(
            serviceProvider.GetService<IDietTypeHotelRelationService>(),
            await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext))
            );
    }
}