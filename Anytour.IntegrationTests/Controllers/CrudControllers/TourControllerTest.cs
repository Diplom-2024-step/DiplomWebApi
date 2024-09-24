//using Anytour.IntegrationTests.shared;
//using AnytourApi.Application.Repositories.Models;
//using AnytourApi.Application.Services.Models.Cities;
//using AnytourApi.Application.Services.Models.Tours;
//using AnytourApi.Domain.Models.Enteties;
//using AnytourApi.Dtos.Dto.Models.Tours;
//using AnytourApi.Dtos.Shared;
//using AnytourApi.EfPersistence.Repositories.Models;
//using AnytourApi.Infrastructure.LinkFactories;
//using AnytourApi.SharedModels.Models;
//using AnytourApi.WebApi.Controllers.Tours;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.Extensions.DependencyInjection;

//namespace Anytour.IntegrationTests.Controllers.CrudControllers;

//public class TourControllerTest : BaseCrudControllerTest<
//    GetTourDto,
//    UpdateTourDto,
//    CreateTourDto,
//    ITourService,
//    Tour,
//    GetTourDto,
//    ReturnPageDto<GetTourDto>,
//    TourController>
//{
//    public TourControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
//    {
//    }


//    protected override async Task MutationBeforeDtoCreation(CreateTourDto createDto,
//      IServiceProvider alternativeServices)
//    {
//        createDto.HotelId = await SharedHotelModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        createDto.FromCityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        createDto.ToCityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        createDto.TransportationTypeId = await SharedTransportationTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        createDto.RoomTypeId = await SharedRoomTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        createDto.DietTypeId = await SharedDietTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);

//    }

//    protected override async Task MutationBeforeDtoUpdate(UpdateTourDto updateDto,
//         IServiceProvider alternativeServices)
//    {
//        updateDto.HotelId = await SharedHotelModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        updateDto.FromCityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        updateDto.ToCityId = await SharedCityModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        updateDto.TransportationTypeId = await SharedTransportationTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        updateDto.RoomTypeId = await SharedRoomTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        updateDto.DietTypeId = await SharedDietTypeModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);

//    }

//    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
//    {

//        alternativeServices.AddSingleton(AppDbContext);

//        alternativeServices.AddSingleton(Mapper);

//        alternativeServices.AddSingleton(UserManager);

//        alternativeServices.AddSingleton(RoleManager);

//        SharedTourModels.AddAllDependencies(alternativeServices);

//        return alternativeServices;
//    }

//    protected override async Task<TourController> GetController(IServiceProvider alternativeServices)
//    {
//        return new TourController(alternativeServices.GetRequiredService<ITourService>(), new LinkFactory(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
//    }

//    protected override CreateTourDto GetCreateDtoSample()
//    {
//        return SharedTourModels.GetSampleCreateDto();
//    }


//    protected override Tour GetModelSample()
//    {
//        return SharedTourModels.GetSample();
//    }

//    protected override UpdateTourDto GetUpdateDtoSample()
//    {
//        return SharedTourModels.GetSampleUpdateDto();
//    }
//}
