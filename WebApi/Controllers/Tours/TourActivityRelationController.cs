using AnytourApi.Application.Services.Relations.TourActivities;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using WebApiForHikka.WebApi.Shared.RelationController;

namespace AnytourApi.WebApi.Controllers.Tours;

public class TourActivityRelationController(ITourActivityRelationService relationService, IHttpContextAccessor httpContextAccessor) :
    RelationController<TourActivity, Tour, Activity, ITourActivityRelationService>(relationService, httpContextAccessor);