using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.ForSports;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ForSports;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.ForSports;

public class ForSportsServiceTest : SharedServiceTest<
    GetForSportDto,
    CreateForSportDto,
    UpdateForSportDto,
    ForSport,
    GetForSportDto,
    IForSportRepository,
    IForSportService
    >
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(GetDatabaseContext());

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton<IForSportRepository, ForSportRepository>();


        return alternativeServices;
    }

    protected override CreateForSportDto GetCreateDtoSample()
    {
        return SharedForSportModels.GetSampleCreateDto();
    }

    protected override UpdateForSportDto GetUpdateDtoSample()
    {
        return SharedForSportModels.GetSampleUpdateDto();
    }

    protected override IForSportService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new ForSportService(builder.GetRequiredService<IForSportRepository>(), Mapper);
    }
}
