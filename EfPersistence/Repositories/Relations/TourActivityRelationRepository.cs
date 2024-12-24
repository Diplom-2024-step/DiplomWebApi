using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;

namespace AnytourApi.EfPersistence.Repositories.Relations;

public class TourActivityRelationRepository : RelationRepository<TourActivity, Tour, Activity>, ITourActivityRelationRepository
{
    public TourActivityRelationRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
