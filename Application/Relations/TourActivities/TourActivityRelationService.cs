using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;

namespace AnytourApi.Application.Services.Relations.TourActivities;

public class TourActivityRelationService(ITourActivityRelationRepository relationRepository) :
    RelationService<TourActivity, Tour, Activity, ITourActivityRelationRepository>(relationRepository),
    ITourActivityRelationService;
