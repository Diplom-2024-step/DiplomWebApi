using AnytourApi.Application.Services.Relations.Histories;
using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using WebApiForHikka.WebApi.Shared.RelationController;

namespace AnytourApi.WebApi.Controllers.Tours;

public class HistoryRelationController(IHistoryRelationService relationService, IHttpContextAccessor httpContextAccessor) :
    RelationController<History, User, Tour, IHistoryRelationService>(relationService, httpContextAccessor);

