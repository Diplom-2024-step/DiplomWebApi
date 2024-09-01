using Anytour.IntegrationTests.shared;
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.InHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.InHotels;
using AnytourApi.Dtos.Shared;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Anytour.IntegrationTests.Controllers.CrudControllers;

public class InHotelControllerTest : BaseCrudControllerTest<
    GetInHotelDto,
    UpdateInHotelDto,
    CreateInHotelDto,
    IInHotelService,
    InHotel,
    GetInHotelDto,
    ReturnPageDto<GetInHotelDto>,
    InHotelController>
{
    public InHotelControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        alternativeServices.AddSingleton<IInHotelRepository, InHotelRepository>();

        alternativeServices.AddSingleton<IInHotelService, InHotelService>();

        return alternativeServices;
    }

    protected override async Task<InHotelController> GetController(IServiceProvider alternativeServices)
    {
        return new InHotelController(alternativeServices.GetRequiredService<IInHotelService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override CreateInHotelDto GetCreateDtoSample()
    {
        return SharedInHotelModels.GetSampleCreateDto();
    }


    protected override InHotel GetModelSample()
    {
        return SharedInHotelModels.GetSample();
    }

    protected override UpdateInHotelDto GetUpdateDtoSample()
    {
        return SharedInHotelModels.GetSampleUpdateDto();
    }
}
