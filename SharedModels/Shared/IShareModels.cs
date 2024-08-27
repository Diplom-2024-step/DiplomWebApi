using AnytourApi.Domain.Models.Shared;
using AnytourApi.Dtos.Shared;

namespace AnytourApi.SharedModels.Shared;

public interface IShareModels<TCreateDto, TUpdateDto,TModel>
    where TModel : class, IModel
    where TUpdateDto : ModelDto
{
    public abstract static TModel GetSample();

    public abstract static TModel GetSampleForUpdate();

    public abstract static TCreateDto GetSampleCreateDto();

    public abstract static TUpdateDto GetSampleUpdateDto();

}
