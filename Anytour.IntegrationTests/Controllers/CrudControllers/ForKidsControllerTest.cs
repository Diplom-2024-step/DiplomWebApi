using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.ForKids;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ForKids;
using AnytourApi.Dtos.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers
{
    public class ForKidsControllerTest : BaseCrudControllerTest<
        GetForKidDto,
        UpdateForKidDto,
        CreateForKidDto,
        IForKidsService,
        ForKid,
        GetForKidDto,
        ReturnPageDto<GetForKidDto>,
        ForKidsController>
    {
        public ForKidsControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
        {
            alternativeServices.AddSingleton(AppDbContext);
            alternativeServices.AddSingleton(Mapper);
            alternativeServices.AddSingleton(UserManager);
            alternativeServices.AddSingleton(RoleManager);
            alternativeServices.AddSingleton<IForKidsRepository, ForKidsRepository>();
            alternativeServices.AddSingleton<IForKidsService, ForKidsService>();
            return alternativeServices;
        }

        protected override async Task<ForKidsController> GetController(IServiceProvider alternativeServices)
        {
            return new ForKidsController(alternativeServices.GetRequiredService<IForKidsService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
        }

        protected override CreateForKidDto GetCreateDtoSample()
        {
            return SharedForKidsModels.GetSampleCreateDto();
        }

        protected override ForKid GetModelSample()
        {
            return SharedForKidsModels.GetSample();
        }

        protected override UpdateForKidDto GetUpdateDtoSample()
        {
            return SharedForKidsModels.GetSampleUpdateDto();
        }
    }
}
