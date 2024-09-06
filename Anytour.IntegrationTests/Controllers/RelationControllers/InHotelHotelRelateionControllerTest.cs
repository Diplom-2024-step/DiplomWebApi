using Anytour.IntegrationTests.shared;
using Anytour.IntegrationTests.Shared;
using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Relations.InHotelHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Repositories.Relations;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers.Hotels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Anytour.IntegrationTests.Controllers.RelationControllers;

public class InHotelHotelRelateionControllerTest : BaseRelationControllerTest<
    InHotelHotel, InHotel, Hotel,
    InHotelHotelRelationController, IInHotelHotelRelationService, IInHotelHotelRelationRepository
    >
{
    public InHotelHotelRelateionControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override Task<Guid> CreateFirstModel(IServiceProvider serviceProvider)
    {
        return SharedInHotelModels.CreateModelWithAllDependenciesAsync(serviceProvider, CancellationToken);
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
        SharedInHotelModels.AddAllDependencies(alternativeServices);

        alternativeServices.AddScoped<IInHotelHotelRelationRepository, InHotelHotelRelationRepository>();

        alternativeServices.AddScoped<IInHotelHotelRelationService, InHotelHotelRelationService>();

        return alternativeServices;
    }

    protected override async Task<InHotelHotelRelationController>  GetRelationController(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        return new InHotelHotelRelationController(
            serviceProvider.GetService<IInHotelHotelRelationService>(),
            await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext))
            );
    }
}
