using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.ReviewOnCompanies;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Repositories;

namespace AnytourApi.UnitTests.Repositories.CrudRepositories.ReviewOnCompanies;

public class ReviewOnCompanyRepositoryTest : SharedRepositoryTest<ReviewOnCompany, IReviewOnCompanyRepository>
{
    protected override IReviewOnCompanyRepository GetRepository(AppDbContext appDbContext)
    {
        return new ReviewOnCompanyRepository(
            appDbContext
            );
    }

    protected override ReviewOnCompany GetSample()
    {
        return SharedReviewOnCompanyModels.GetSample();
    
    }

    protected override ReviewOnCompany GetSampleForUpdate()
    {
        return SharedReviewOnCompanyModels.GetSampleForUpdate();
    }
}