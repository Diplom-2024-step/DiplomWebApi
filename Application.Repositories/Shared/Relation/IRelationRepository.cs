using AnytourApi.Domain.Models.Shared;

namespace AnytourApi.Application.Repositories.Shared.Relation;

public interface IRelationRepository<TModel, TFirstModel, TSecondModel>
    where TModel : RelationModel<TFirstModel, TSecondModel>
    where TFirstModel : class, IModel
    where TSecondModel : class, IModel
{
    Task DeleteAsync(Guid firstId, Guid secondId, CancellationToken cancellationToken);
    Task<TModel?> GetAsync(Guid firstId, Guid secondId, CancellationToken cancellationToken);
    TModel? Get(Guid firstId, Guid secondId);

    bool CheckIfModelsWithThisIdsExist(Guid firstId, Guid secondId);
}