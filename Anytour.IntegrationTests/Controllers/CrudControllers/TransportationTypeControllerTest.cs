using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.TransportationTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.TransportationTypes;
using AnytourApi.Dtos.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers;

public class TransportationTypeControllerTest : BaseCrudControllerTest
    <
    GetTransportationTypeDto,
    UpdateTransportationTypeDto,
    CreateTransportationTypeDto,
    ITransportationTypeService,
    TransportationType,
    GetTransportationTypeDto,
    ReturnPageDto<GetTransportationTypeDto>,
    TransportationTypeController
    >
{
    public TransportationTypeControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        SharedTransportationTypeModels.AddAllDependencies(alternativeServices);


        return alternativeServices;
    }

    protected override async Task<TransportationTypeController> GetController(IServiceProvider alternativeServices)
    {
        return new TransportationTypeController(alternativeServices.GetRequiredService<ITransportationTypeService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override CreateTransportationTypeDto GetCreateDtoSample()
    {
        return SharedTransportationTypeModels.GetSampleCreateDto();
    }


    protected override TransportationType GetModelSample()
    {
        return SharedTransportationTypeModels.GetSample();
    }

    protected override UpdateTransportationTypeDto GetUpdateDtoSample()
    {
        return SharedTransportationTypeModels.GetSampleUpdateDto();
    }
}
