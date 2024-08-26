using AnytourApi.Domain.Models.Shared;

namespace AnytourApi.SharedModels.Shared;

public interface IShareModels<TModel>
    where TModel : class, IModel
{
    public abstract static TModel GetSample();

    public abstract static TModel GetSampleForUpdate();

}
