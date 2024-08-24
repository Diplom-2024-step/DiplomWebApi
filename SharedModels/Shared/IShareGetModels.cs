using Domain.Models.Shared;

namespace SharedModels.Shared;

public interface IShareGetModels<TModel>
    where TModel : class, IModel
{
    public abstract static TModel GetSample();

    public abstract static TModel GetSampleForUpdate();

}
