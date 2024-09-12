using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Polimorfizms.Photoables;
using AnytourApi.Application.Services.Models.Countries;
using AnytourApi.Application.Services.Models.Photos;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Cities;
using AnytourApi.Dtos.Dto.Models.Photos;
using AnytourApi.Dtos.Shared;
using AnytourApi.SharedModels.MockObjects;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers;

public class PhotoControllerTest : BaseCrudControllerTest
    <
    GetPhotoDto,
    UpdatePhotoDto,
    CreatePhotoDto,
    IPhotoService,
    Photo,
    GetPhotoDto,
    ReturnPageDto<GetPhotoDto>,
    PhotoController
    >
{
    public PhotoControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);


        SharedPhotoModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }

    protected override async Task<PhotoController> GetController(IServiceProvider alternativeServices)
    {
        return new PhotoController(alternativeServices.GetRequiredService<IPhotoService>(), new FileHelperMock(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override CreatePhotoDto GetCreateDtoSample()
    {
        return SharedPhotoModels.GetSampleCreateDto();
    }


    protected override Photo GetModelSample()
    {
        return SharedPhotoModels.GetSample();
    }

    protected override UpdatePhotoDto GetUpdateDtoSample()
    {
        return SharedPhotoModels.GetSampleUpdateDto();
    }

    protected override async Task MutationBeforeDtoCreation(CreatePhotoDto createDto,
     IServiceProvider alternativeServices)
    {

        var id = await alternativeServices.GetRequiredService<IPhotoableRepository>().AddAsync(SharedPhotoableModels.GetSample(), CancellationToken);
        createDto.PhotoableId = id;


    }

    protected override async Task MutationBeforeDtoUpdate(UpdatePhotoDto updateDto,
         IServiceProvider alternativeServices)
    {


        var id = await alternativeServices.GetRequiredService<IPhotoableRepository>().AddAsync(SharedPhotoableModels.GetSampleForUpdate(), CancellationToken);
        updateDto.PhotoableId = id;
    }
}