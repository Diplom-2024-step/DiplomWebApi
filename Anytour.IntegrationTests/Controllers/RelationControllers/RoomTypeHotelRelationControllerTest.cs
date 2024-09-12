using Anytour.IntegrationTests.shared;
using Anytour.IntegrationTests.Shared;
using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Relations.RoomTypeHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers.Hotels;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.RelationControllers;

public class RoomTypeHotelRelationControllerTest : BaseRelationControllerTest<
    RoomTypeHotel, RoomType, Hotel,
    RoomTypeHotelRelationController, IRoomTypeHotelRelationService, IRoomTypeHotelRelationRepository>
{
    public RoomTypeHotelRelationControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override Task<Guid> CreateFirstModel(IServiceProvider serviceProvider)
    {
        return SharedRoomTypeModels.CreateModelWithAllDependenciesAsync(serviceProvider, CancellationToken);
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
        SharedRoomTypeModels.AddAllDependencies(alternativeServices);

        alternativeServices.AddScoped<IRoomTypeHotelRelationRepository, RoomTypeHotelRelationRepository>();

        alternativeServices.AddScoped<IRoomTypeHotelRelationService, RoomTypeHotelRelationService>();

        return alternativeServices;
    }

    protected override async Task<RoomTypeHotelRelationController> GetRelationController(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        return new RoomTypeHotelRelationController(
            serviceProvider.GetService<IRoomTypeHotelRelationService>(),
            await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext))
            );
    }
}
