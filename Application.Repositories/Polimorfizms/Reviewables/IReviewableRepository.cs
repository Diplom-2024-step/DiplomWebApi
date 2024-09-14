using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Domain.Models.Shared;

namespace AnytourApi.Application.Repositories.Polimorfizms.Reviewables;

public interface IReviewableRepository : ICrudRepository<Reviewable>;
