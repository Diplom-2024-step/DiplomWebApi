using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Activities;
using AnytourApi.Application.Services.Models.Countries;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Activities;
using AnytourApi.Dtos.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.Infrastructure.LinkFactories;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers;
using Faker;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers;

public class ActivityControllerTest : BaseCrudControllerTest<
    GetActivityDto,
    UpdateActivityDto,
    CreateActivityDto,
    IActivityService,
    Activity,
    GetActivityDto,
    ReturnPageDto<GetActivityDto>,
    ActivityController>
{
    public ActivityControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        SharedActivityModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }

    protected override async Task<ActivityController> GetController(IServiceProvider alternativeServices)
    {
        return new ActivityController(alternativeServices.GetRequiredService<IActivityService>(), new LinkFactory(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }


    protected override async Task MutationBeforeDtoCreation(CreateActivityDto createDto, IServiceProvider alternativeServices)
    {
       var countryId = await alternativeServices.GetRequiredService<ICountryService>().CreateAsync(SharedCountryModels.GetSampleCreateDto(), CancellationToken);
        createDto.CountryId = countryId;
    }

    protected override async Task MutationBeforeDtoUpdate(UpdateActivityDto updateActivityDto, IServiceProvider alternativeServices)
    {
       var countryId = await alternativeServices.GetRequiredService<ICountryService>().CreateAsync(SharedCountryModels.GetSampleCreateDto(), CancellationToken);
        updateActivityDto.CountryId = countryId;
    }



    protected override CreateActivityDto GetCreateDtoSample()
    {
        return SharedActivityModels.GetSampleCreateDto();
    }


    protected override Activity GetModelSample()
    {
        return SharedActivityModels.GetSample();
    }

    protected override UpdateActivityDto GetUpdateDtoSample()
    {
        return SharedActivityModels.GetSampleUpdateDto();
    }
}
