using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.InRooms;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.InRooms;
using AnytourApi.Dtos.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers
{
    public class InRoomControllerTest : BaseCrudControllerTest<
        GetInRoomDto,
        UpdateInRoomDto,
        CreateInRoomDto,
        IInRoomService,
        InRoom,
        GetInRoomDto,
        ReturnPageDto<GetInRoomDto>,
        InRoomController>
    {
        public InRoomControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
        {
            alternativeServices.AddSingleton(AppDbContext);
            alternativeServices.AddSingleton(Mapper);
            alternativeServices.AddSingleton(UserManager);
            alternativeServices.AddSingleton(RoleManager);
            alternativeServices.AddSingleton<IInRoomRepository, InRoomRepository>();
            alternativeServices.AddSingleton<IInRoomService, InRoomService>();
            return alternativeServices;
        }

        protected override async Task<InRoomController> GetController(IServiceProvider alternativeServices)
        {
            return new InRoomController(alternativeServices.GetRequiredService<IInRoomService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
        }

        protected override CreateInRoomDto GetCreateDtoSample()
        {
            return SharedInRoomModels.GetSampleCreateDto();
        }

        protected override InRoom GetModelSample()
        {
            return SharedInRoomModels.GetSample();
        }

        protected override UpdateInRoomDto GetUpdateDtoSample()
        {
            return SharedInRoomModels.GetSampleUpdateDto();
        }
    }
}
