using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Relations.Histories;
using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;

namespace AnytourApi.Application.Services.Relations.Histories;

public class HistoryRelationService(IHistoryRelationRepository relationRepository) :
    RelationService<History, User, Tour, IHistoryRelationRepository>(relationRepository),
    IHistoryRelationService;

