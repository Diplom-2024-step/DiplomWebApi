//using Anytour.IntegrationTests.shared;
//using AnytourApi.Application.Services.Models.ProcessedOrders;
//using AnytourApi.Domain.Models.Enteties;
//using AnytourApi.Dtos.Dto.Models.ProcessedOrders;
//using AnytourApi.Dtos.Shared;
//using AnytourApi.SharedModels.Models;
//using AnytourApi.WebApi.Controllers.Orders;
//using Microsoft.Extensions.DependencyInjection;

//namespace Anytour.IntegrationTests.Controllers.CrudControllers;

//public class ProcessedOrderControllerTest : BaseCrudControllerTest<
//    GetProcessedOrderDto,
//    UpdateProcessedOrderDto,
//    CreateProcessedOrderDto,
//    IProcessedOrderService,
//    ProcessedOrder,
//    GetProcessedOrderDto,
//    ReturnPageDto<GetProcessedOrderDto>,
//    ProcessedOrderController>
//{
//    public ProcessedOrderControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
//    {
//    }


//    protected override async Task MutationBeforeDtoCreation(CreateProcessedOrderDto createDto,
//      IServiceProvider alternativeServices)
//    {
//        createDto.OrderId = await SharedOrderModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        createDto.UserId = await SharedUserModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        createDto.StatusId = await SharedOrderStatusModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//    }

//    protected override async Task MutationBeforeDtoUpdate(UpdateProcessedOrderDto updateDto,
//         IServiceProvider alternativeServices)
//    {
//        updateDto.OrderId = await SharedOrderModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        updateDto.UserId = await SharedUserModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken); ;
//        updateDto.StatusId = await SharedOrderStatusModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//    }

//    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
//    {

//        alternativeServices.AddSingleton(AppDbContext);

//        alternativeServices.AddSingleton(Mapper);

//        alternativeServices.AddSingleton(UserManager);

//        alternativeServices.AddSingleton(RoleManager);

//        SharedProcessedOrderModels.AddAllDependencies(alternativeServices);

//        return alternativeServices;
//    }

//    protected override async Task<ProcessedOrderController> GetController(IServiceProvider alternativeServices)
//    {
//        return new ProcessedOrderController(alternativeServices.GetRequiredService<IProcessedOrderService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
//    }

//    protected override CreateProcessedOrderDto GetCreateDtoSample()
//    {
//        return SharedProcessedOrderModels.GetSampleCreateDto();
//    }


//    protected override ProcessedOrder GetModelSample()
//    {
//        return SharedProcessedOrderModels.GetSample();
//    }

//    protected override UpdateProcessedOrderDto GetUpdateDtoSample()
//    {
//        return SharedProcessedOrderModels.GetSampleUpdateDto();
//    }
//}
