using Anytour.IntegrationTests.shared;
using Anytour.IntegrationTests.Shared;
using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Relations.ForSportHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers.Hotels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Anytour.IntegrationTests.Controllers.RelationControllers;

public class ForSportHotelRelationControllerTest : BaseRelationControllerTest<
    ForSportHotel, ForSport, Hotel,
    ForSportHotelRelationController, IForSportHotelRelationService, IForSportHotelRelationRepository>
{
    public ForSportHotelRelationControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override Task<Guid> CreateFirstModel(IServiceProvider serviceProvider)
    {
        return SharedForSportModels.CreateModelWithAllDependenciesAsync(serviceProvider, CancellationToken);
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
        SharedForSportModels.AddAllDependencies(alternativeServices);

        alternativeServices.AddScoped<IForSportHotelRelationRepository, ForSportHotelRelationRepository>();

        alternativeServices.AddScoped<IForSportHotelRelationService, ForSportHotelRelationService>();

        return alternativeServices;
    }

    protected override async Task<ForSportHotelRelationController> GetRelationController(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        return new ForSportHotelRelationController(
            serviceProvider.GetService<IForSportHotelRelationService>(),
            await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext))
            );
    }
}
