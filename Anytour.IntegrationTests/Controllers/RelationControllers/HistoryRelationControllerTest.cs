//using Anytour.IntegrationTests.shared;
//using Anytour.IntegrationTests.Shared;
//using AnytourApi.Application.Repositories.Relations;
//using AnytourApi.Application.Repositories.Users;
//using AnytourApi.Application.Services.Relations.Histories;
//using AnytourApi.Domain.Models;
//using AnytourApi.Domain.Models.Enteties;
//using AnytourApi.Domain.Models.Relations;
//using AnytourApi.EfPersistence.Repositories.Relations;
//using AnytourApi.SharedModels.Models;
//using AnytourApi.WebApi.Controllers.Tours;
//using Microsoft.Extensions.DependencyInjection;

//namespace Anytour.IntegrationTests.Controllers.RelationControllers;

//public class HistoryRelationControllerTest : BaseRelationControllerTest<
//    History, User, Tour,
//    HistoryRelationController, IHistoryRelationService, IHistoryRelationRepository>
//{
//    private Guid? UserId { get; set; }

//    private readonly Object _userLocker = new();

//    public HistoryRelationControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
//    {
//    }

//    protected override async Task<Guid> CreateFirstModel(IServiceProvider serviceProvider)
//    {
//        lock (_userLocker)
//        {
//            if (UserId == null)
//            {
//                var user = SharedUserModels.GetSample();
//                user.UserName = "FavoriteTourRelationControllerTest";
//                user.Email = "FavoriteTourRelationControllerTest@gmail.com";
//                UserId = serviceProvider.GetService<IUserRepository>().Add(user);
//            }
//            return UserId ?? new Guid();
//        }
        
//    }

//    protected override Task<Guid> CreateSecondModel(IServiceProvider serviceProvider)
//    {
//        return SharedTourModels.CreateModelWithAllDependenciesAsync(serviceProvider, CancellationToken);
//    }

//    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
//    {
//        alternativeServices.AddSingleton(AppDbContext);
//        alternativeServices.AddSingleton(GetRoleManager(AppDbContext));
//        alternativeServices.AddSingleton(GetUserManager(AppDbContext));
//        alternativeServices.AddSingleton(Mapper);

//        SharedTourModels.AddAllDependencies(alternativeServices);
//        SharedUserModels.AddAllDependencies(alternativeServices);
        
//        alternativeServices.AddScoped<IHistoryRelationRepository, HistoryRelationRepository>();

//        alternativeServices.AddScoped<IHistoryRelationService, HistoryRelationService>();



//        return alternativeServices;
//    }

//    protected override async Task<HistoryRelationController> GetRelationController(IServiceProvider serviceProvider, CancellationToken cancellationToken)
//    {
//        return new HistoryRelationController(
//            serviceProvider.GetService<IHistoryRelationService>(),
//            await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext))
//            );
//    }
//}
