using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Reviews;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Reviews;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.Reviews;

public class ReviewServiceTest : SharedServiceTest<
    GetReviewDto,
    CreateReviewDto,
    UpdateReviewDto,
    Review,
    GetReviewDto,
    IReviewRepository,
    IReviewService
    >
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(GetDatabaseContext());

        alternativeServices.AddSingleton(Mapper);

        SharedReviewModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }

    protected override CreateReviewDto GetCreateDtoSample()
    {
        return SharedReviewModels.GetSampleCreateDto();
    }

    protected override UpdateReviewDto GetUpdateDtoSample()
    {
        return SharedReviewModels.GetSampleUpdateDto();
    }

    protected override IReviewService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new ReviewService(builder.GetRequiredService<IReviewRepository>(), Mapper);

    }
}