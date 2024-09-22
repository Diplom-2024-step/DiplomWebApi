using AnytourApi.Application.Repositories.Shared.Relation;
using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;

namespace AnytourApi.Application.Repositories.Relations;

public interface IHistoryRelationRepository : IRelationRepository<History, User, Tour>;
