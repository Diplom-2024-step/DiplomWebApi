using AnytourApi.Application.Repositories.Shared.Relation;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.EfPersistence.Data;
using Microsoft.EntityFrameworkCore;
namespace AnytourApi.EfPersistence.Repositories;

public abstract class RelationRepository<TModel, TFirstModel, TSecondModel> :
    IRelationRepository<TModel, TFirstModel, TSecondModel>
    where TModel : RelationModel<TFirstModel, TSecondModel>
    where TFirstModel : class, IModel
    where TSecondModel : class, IModel
{

    protected AppDbContext DbContext;

    public RelationRepository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public bool CheckIfModelsWithThisIdsExist(Guid firstId, Guid secondId)
    {
        var firstEntity = DbContext.Set<TFirstModel>()
            .FirstOrDefault(e => e.Id == firstId);
        if (firstEntity == null) return false;

        var secondEntity = DbContext.Set<TSecondModel>()
            .FirstOrDefault(e => e.Id == secondId);
        return secondEntity != null;
    }

    public virtual async Task DeleteAsync(Guid firstId, Guid secondId, CancellationToken cancellationToken)
    {
        var entity = await DbContext.Set<TModel>()
            .FirstOrDefaultAsync(e => e.FirstId == firstId && e.SecondId == secondId);

        if (entity is null)
            return;

        DbContext.Set<TModel>().Remove(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public TModel? Get(Guid firstId, Guid secondId)
    {
        return DbContext.Set<TModel>().FirstOrDefault(e => e.FirstId == firstId && e.SecondId == secondId);
    }

    public async Task<TModel?> GetAsync(Guid firstId, Guid secondId, CancellationToken cancellationToken)
    {
        return await DbContext.Set<TModel>().FirstOrDefaultAsync(e => e.FirstId == firstId && e.SecondId == secondId);
    }
}