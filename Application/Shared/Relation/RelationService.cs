using AnytourApi.Application.Repositories.Shared.Relation;
using AnytourApi.Domain.Models.Shared;

namespace AnytourApi.Application.Services.Shared.Relation;

public abstract class RelationService<TModel, TFirstModel, TSecondModel, TRepository>
    : IRelationService<TModel, TFirstModel, TSecondModel>
    where TModel : RelationModel<TFirstModel, TSecondModel>
    where TRepository : IRelationRepository<TModel, TFirstModel, TSecondModel>
    where TFirstModel : class, IModel
    where TSecondModel : class, IModel
{

    protected TRepository RelationRepository;

    protected RelationService(TRepository relationRepository)
    {
        RelationRepository = relationRepository;
    }

    public bool CheckIfModelsWithThisIdsExist(Guid firstId, Guid secondId)
    {
        return RelationRepository.CheckIfModelsWithThisIdsExist(firstId, secondId);
    }

    public Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken)
    {
        return RelationRepository.CreateAsync(model, cancellationToken);
    }

    public async Task DeleteAsync(Guid firstId, Guid secondId, CancellationToken cancellationToken)
    {
        await RelationRepository.DeleteAsync(firstId, secondId, cancellationToken);
    }

    public TModel? Get(Guid firstId, Guid secondId)
    {
        return RelationRepository.Get(firstId, secondId);
    }

    public async Task<TModel?> GetAsync(Guid firstId, Guid secondId, CancellationToken cancellationToken)
    {
        return await RelationRepository.GetAsync(firstId, secondId, cancellationToken);
    }
}