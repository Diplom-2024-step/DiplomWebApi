using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.ForSports;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ForSports;
using AnytourApi.Dtos.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers;

public class ForSportControllerTest : BaseCrudControllerTest<
    GetForSportDto,
    UpdateForSportDto,
    CreateForSportDto,
    IForSportService,
    ForSport,
    GetForSportDto,
    ReturnPageDto<GetForSportDto>,
    ForSportController>
{
    public ForSportControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        SharedForSportModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }

    protected override async Task<ForSportController> GetController(IServiceProvider alternativeServices)
    {
        return new ForSportController(alternativeServices.GetRequiredService<IForSportService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override CreateForSportDto GetCreateDtoSample()
    {
        return SharedForSportModels.GetSampleCreateDto();
    }


    protected override ForSport GetModelSample()
    {
        return SharedForSportModels.GetSample();
    }

    protected override UpdateForSportDto GetUpdateDtoSample()
    {
        return SharedForSportModels.GetSampleUpdateDto();
    }
}