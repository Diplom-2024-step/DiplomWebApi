using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Polimorfizms.ReviewablePhotoables;
using AnytourApi.Application.Repositories.Polimorfizms.Reviewables;
using AnytourApi.Application.Services.Models.Reviews;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Reviews;
using AnytourApi.Dtos.Shared;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers;

//public class ReviewControllerTest : BaseCrudControllerTest<
//    GetReviewDto,
//    UpdateReviewDto,
//    CreateReviewDto,
//    IReviewService,
//    Review,
//    GetReviewDto,
//    ReturnPageDto<GetReviewDto>,
//    ReviewController>
//{
//    public ReviewControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
//    {
//    }

//    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
//    {

//        alternativeServices.AddSingleton(AppDbContext);

//        alternativeServices.AddSingleton(Mapper);

//        alternativeServices.AddSingleton(UserManager);

//        alternativeServices.AddSingleton(RoleManager);

//        SharedReviewModels.AddAllDependencies(alternativeServices);

//        return alternativeServices;
//    }

//    protected override async Task<ReviewController> GetController(IServiceProvider alternativeServices)
//    {
//        return new ReviewController(alternativeServices.GetRequiredService<IReviewService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
//    }

//    protected override CreateReviewDto GetCreateDtoSample()
//    {
//        return SharedReviewModels.GetSampleCreateDto();
//    }


//    protected override Review GetModelSample()
//    {
//        return SharedReviewModels.GetSample();
//    }

//    protected override UpdateReviewDto GetUpdateDtoSample()
//    {
//        return SharedReviewModels.GetSampleUpdateDto();
//    }

//    protected override async Task MutationBeforeDtoCreation(CreateReviewDto createDto,
//    IServiceProvider alternativeServices)
//    {

//        var id = await alternativeServices.GetRequiredService<IReviewablePhotoableRepository>().AddAsync(SharedReviewablePhotoableModels.GetSample(), CancellationToken);
//        createDto.ReviewablePhotoableId = id;


//    }

//    protected override async Task MutationBeforeDtoUpdate(UpdateReviewDto updateDto,
//         IServiceProvider alternativeServices)
//    {


//        var id = await alternativeServices.GetRequiredService<IReviewablePhotoableRepository>().AddAsync(SharedReviewablePhotoableModels.GetSampleForUpdate(), CancellationToken);
//        updateDto.ReviewablePhotoableId = id;
//    }
//}