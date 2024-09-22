using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;

namespace AnytourApi.EfPersistence.Repositories.Relations;

public class HistoryRelationRepository(AppDbContext dbContext) :
    RelationRepository<History, User, Tour>(dbContext),
    IHistoryRelationRepository;
