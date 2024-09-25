//using Anytour.IntegrationTests.shared;
//using Anytour.IntegrationTests.Shared;
//using AnytourApi.Application.Repositories.Relations;
//using AnytourApi.Application.Repositories.Users;
//using AnytourApi.Application.Services.Relations.BeachTypeHotels;
//using AnytourApi.Application.Services.Relations.FavoriteTours;
//using AnytourApi.Application.Services.Users;
//using AnytourApi.Domain.Models;
//using AnytourApi.Domain.Models.Enteties;
//using AnytourApi.Domain.Models.Relations;
//using AnytourApi.EfPersistence.Repositories.Relations;
//using AnytourApi.SharedModels.Models;
//using AnytourApi.WebApi.Controllers.Hotels;
//using AnytourApi.WebApi.Controllers.Tours;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection.Extensions;
//using System.Threading.Tasks;

//namespace Anytour.IntegrationTests.Controllers.RelationControllers;

//public class FavoriteTourRelationControllerTest : BaseRelationControllerTest<
//    FavoriteTour, Tour, User,
//    FavoriteTourRelationController, IFavoriteTourRelationService, IFavoriteTourRelationRepository>
//{
//    private Guid? UserId { get; set; }

//    private readonly Object _userLocker = new();

//    public FavoriteTourRelationControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
//    {
//    }

//    protected override Task<Guid> CreateFirstModel(IServiceProvider serviceProvider)
//    {
//        return SharedTourModels.CreateModelWithAllDependenciesAsync(serviceProvider, CancellationToken);
//    }

//    protected override async Task<Guid> CreateSecondModel(IServiceProvider serviceProvider)
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

//    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
//    {
//        alternativeServices.AddSingleton(AppDbContext);
//        alternativeServices.AddSingleton(GetRoleManager(AppDbContext));
//        alternativeServices.AddSingleton(GetUserManager(AppDbContext));
//        alternativeServices.AddSingleton(Mapper);

//        SharedUserModels.AddAllDependencies(alternativeServices);
//        SharedTourModels.AddAllDependencies(alternativeServices);

//        alternativeServices.AddScoped<IFavoriteTourRelationRepository, FavoriteTourRelationRepository>();

//        alternativeServices.AddScoped<IFavoriteTourRelationService, FavoriteTourRelationService>();



//        return alternativeServices;
//    }

//    protected override async Task<FavoriteTourRelationController> GetRelationController(IServiceProvider serviceProvider, CancellationToken cancellationToken)
//    {
//        return new FavoriteTourRelationController(
//            serviceProvider.GetService<IFavoriteTourRelationService>(),
//            await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext))
//            );
//    }
//}
