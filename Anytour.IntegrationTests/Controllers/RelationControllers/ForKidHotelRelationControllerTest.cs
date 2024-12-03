using Anytour.IntegrationTests.shared;
using Anytour.IntegrationTests.Shared;
using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Relations.ForKidHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers.Hotels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Anytour.IntegrationTests.Controllers.RelationControllers;

public class ForKidHotelRelationControllerTest : BaseRelationControllerTest<
    ForKidHotel, ForKid, Hotel,
    ForKidHotelRelationController, IForKidHotelRelationService, IForKidHotelRelationRepository>
{
    public ForKidHotelRelationControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override Task<Guid> CreateFirstModel(IServiceProvider serviceProvider)
    {
        return SharedForKidsModels.CreateModelWithAllDependenciesAsync(serviceProvider, CancellationToken);
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
        SharedForKidsModels.AddAllDependencies(alternativeServices);

        alternativeServices.AddScoped<IForKidHotelRelationRepository, ForKidHotelRelationRepository>();
        alternativeServices.AddScoped<IForKidHotelRelationService, ForKidHotelRelationService>();

        return alternativeServices;
    }

    protected override async Task<ForKidHotelRelationController> GetRelationController(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        return new ForKidHotelRelationController(
            serviceProvider.GetService<IForKidHotelRelationService>(),
            await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext))
        );
    }
}