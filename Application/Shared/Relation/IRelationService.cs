using AnytourApi.Domain.Models.Shared;

namespace AnytourApi.Application.Services.Shared.Relation;

public interface IRelationService<TModel, TFirstModel, TSecondModel>
    where TModel : RelationModel<TFirstModel, TSecondModel>
    where TFirstModel : class, IModel
    where TSecondModel : class, IModel
{
    Task DeleteAsync(Guid firstId, Guid secondId, CancellationToken cancellationToken);
    Task<TModel?> GetAsync(Guid firstId, Guid secondId, CancellationToken cancellationToken);
    TModel? Get(Guid firstId, Guid secondId);

    Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken);

    bool CheckIfModelsWithThisIdsExist(Guid firstId, Guid secondId);
}