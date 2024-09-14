using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Domain.Models.Shared;

namespace AnytourApi.Application.Repositories.Polimorfizms.ReviewablePhotoables;

public interface IReviewablePhotoableRepository : ICrudRepository<ReviewablePhotoable>;
