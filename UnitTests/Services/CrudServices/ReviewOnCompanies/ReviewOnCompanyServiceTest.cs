using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Users;
using AnytourApi.Application.Services.Models.ReviewOnCompanies;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ReviewOnComapnies;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace AnytourApi.UnitTests.Services.CrudServices.ReviewOnCompanies;

public class ReviewOnCompanyServiceTest : SharedServiceTest<
    GetReviewOnCompanyDto,
    CreateReviewOnCompanyDto,
    UpdateOnComapnyReviewDto,
    ReviewOnCompany,
    GetReviewOnCompanyDto,
    IReviewOnCompanyRepository,
    IReviewOnCompanyService
    >
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        var dbContext = GetDatabaseContext();

        alternativeServices.AddSingleton(dbContext);

        alternativeServices.AddSingleton(GetUserManager(dbContext));

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddScoped<IReviewOnCompanyRepository, ReviewOnCompanyRepository>();

        SharedUserModels.AddAllDependencies(alternativeServices);


        return alternativeServices;
    }

    protected override CreateReviewOnCompanyDto GetCreateDtoSample()
    {
        return SharedReviewOnCompanyModels.GetSampleCreateDto();
    }

    protected override UpdateOnComapnyReviewDto GetUpdateDtoSample()
    {
        return SharedReviewOnCompanyModels.GetSampleUpdateDto();
    }

    protected override IReviewOnCompanyService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new ReviewOnComapnyService(builder.GetRequiredService<IReviewOnCompanyRepository>(), builder.GetRequiredService<IUserRepository>(), Mapper);

    }
}