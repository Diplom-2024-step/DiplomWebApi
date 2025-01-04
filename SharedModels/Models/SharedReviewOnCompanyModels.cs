using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.ReviewOnCompanies;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ReviewOnComapnies;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace AnytourApi.SharedModels.Models;

public class SharedReviewOnCompanyModels : SharedModelsBase, IShareModels<CreateReviewOnCompanyDto, UpdateOnComapnyReviewDto, ReviewOnCompany>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<IReviewOnCompanyRepository, ReviewOnCompanyRepository>();

        services.AddScoped<IReviewOnCompanyService, ReviewOnComapnyService>();

    }

    public static  async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {

        return await serviceProvider.GetService<IReviewOnCompanyService>().CreateAsync(
            SharedReviewOnCompanyModels.GetSampleCreateDto(),
            cancellationToken   
            );

    }

    public static ReviewOnCompany GetSample()
    {
        return new ReviewOnCompany()
        {
            Body = "dsada",
            Dwelling = 94,
            OrganizationOfTrips = 91,
            PriceQuality = 40,
            Service = 12,
            User = SharedUserModels.GetSample(),
            CreatedAt = DateTime.UtcNow,
            Score = 3
        };
    }

    public static CreateReviewOnCompanyDto GetSampleCreateDto()
    {
        return new CreateReviewOnCompanyDto()
        {
            Body = "dsadasd",
            Dwelling = 12,
            OrganizationOfTrips = 12,
            PriceQuality = 12,
            Service = 12,
            UserId = Guid.NewGuid(),
            Score = 2
        };
    }

    public static ReviewOnCompany GetSampleForUpdate()
    {
        return new ReviewOnCompany()
        {
            Body = "dasda",
            Dwelling = 21,
            OrganizationOfTrips = 21,
            PriceQuality= 21,
            Service = 21,
            User = SharedUserModels.GetSampleForUpdate(),
            CreatedAt = DateTime.UtcNow,
            Score = 2
        };
    }

    public static UpdateOnComapnyReviewDto GetSampleUpdateDto()
    {
        return new UpdateOnComapnyReviewDto() 
        {
            Body = "dsadasd",
            Dwelling =43,
            OrganizationOfTrips =43,
            PriceQuality = 43,
            Service = 43,
            UserId= Guid.NewGuid(),
            Score = 1,
            Id = Guid.NewGuid()
        };
    }
}
