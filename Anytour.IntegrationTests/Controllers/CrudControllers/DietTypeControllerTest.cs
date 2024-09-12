using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.DietTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.DietTypes;
using AnytourApi.Dtos.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers;

public class DietTypeControllerTest : BaseCrudControllerTest<
    GetDietTypeDto,
    UpdateDietTypeDto,
    CreateDietTypeDto,
    IDietTypeService,
    DietType,
    GetDietTypeDto,
    ReturnPageDto<GetDietTypeDto>,
    DietTypeController>
{
    public DietTypeControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        SharedDietTypeModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }

    protected override async Task<DietTypeController> GetController(IServiceProvider alternativeServices)
    {
        return new DietTypeController(alternativeServices.GetRequiredService<IDietTypeService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override CreateDietTypeDto GetCreateDtoSample()
    {
        return SharedDietTypeModels.GetSampleCreateDto();
    }


    protected override DietType GetModelSample()
    {
        return SharedDietTypeModels.GetSample();
    }

    protected override UpdateDietTypeDto GetUpdateDtoSample()
    {
        return SharedDietTypeModels.GetSampleUpdateDto();
    }
}
