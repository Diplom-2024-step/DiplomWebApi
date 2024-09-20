using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.ForKids;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ForKids;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.ForKids
{
    public class ForKidsServiceTest : SharedServiceTest<
        GetForKidsDto,
        CreateForKidsDto,
        UpdateForKidsDto,
        ForKid,
        GetForKidsDto,
        IForKidsRepository,
        IForKidsService>
    {
        protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
        {
            alternativeServices.AddSingleton(GetDatabaseContext());
            alternativeServices.AddSingleton(Mapper);
            alternativeServices.AddSingleton<IForKidsRepository, ForKidsRepository>();
            return alternativeServices;
        }

        protected override CreateForKidsDto GetCreateDtoSample()
        {
            return SharedForKidsModels.GetSampleCreateDto();
        }

        protected override UpdateForKidsDto GetUpdateDtoSample()
        {
            return SharedForKidsModels.GetSampleUpdateDto();
        }

        protected override IForKidsService GetService(IServiceCollection alternativeServices)
        {
            var builder = alternativeServices.BuildServiceProvider();
            return new ForKidsService(builder.GetRequiredService<IForKidsRepository>(), Mapper);
        }
    }
}
