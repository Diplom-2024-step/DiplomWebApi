using Anytour.IntegrationTests.shared;
using Anytour.IntegrationTests.Shared;
using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Relations.InRoomHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers.Hotels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Anytour.IntegrationTests.Controllers.RelationControllers;

public class InRoomHotelRelationControllerTest : BaseRelationControllerTest<
    InRoomHotel, InRoom, Hotel,
    InRoomHotelRelationController, IInRoomHotelRelationService, IInRoomHotelRelationRepository>
{
    public InRoomHotelRelationControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override Task<Guid> CreateFirstModel(IServiceProvider serviceProvider)
    {
        return SharedInRoomModels.CreateModelWithAllDependenciesAsync(serviceProvider, CancellationToken);
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
        SharedInRoomModels.AddAllDependencies(alternativeServices);

        alternativeServices.AddScoped<IInRoomHotelRelationRepository, InRoomHotelRelationRepository>();

        alternativeServices.AddScoped<IInRoomHotelRelationService, InRoomHotelRelationService>();

        return alternativeServices;
    }

    protected override async Task<InRoomHotelRelationController> GetRelationController(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        return new InRoomHotelRelationController(
            serviceProvider.GetService<IInRoomHotelRelationService>(),
            await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext))
            );
    }
}