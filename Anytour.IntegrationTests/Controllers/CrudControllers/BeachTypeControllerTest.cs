using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.BeachTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.BeachTypes;
using AnytourApi.Dtos.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers;

public class BeachTypeControllerTest : BaseCrudControllerTest<
    GetBeachTypeDto,
    UpdateBeachTypeDto,
    CreateBeachTypeDto,
    IBeachTypeService,
    BeachType,
    GetBeachTypeDto,
    ReturnPageDto<GetBeachTypeDto>,
    BeachTypeController>
{
    public BeachTypeControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        SharedBeachTypeModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }

    protected override async Task<BeachTypeController> GetController(IServiceProvider alternativeServices)
    {
        return new BeachTypeController(alternativeServices.GetRequiredService<IBeachTypeService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override CreateBeachTypeDto GetCreateDtoSample()
    {
        return SharedBeachTypeModels.GetSampleCreateDto();
    }


    protected override BeachType GetModelSample()
    {
        return SharedBeachTypeModels.GetSample();
    }

    protected override UpdateBeachTypeDto GetUpdateDtoSample()
    {
        return SharedBeachTypeModels.GetSampleUpdateDto();
    }
}
