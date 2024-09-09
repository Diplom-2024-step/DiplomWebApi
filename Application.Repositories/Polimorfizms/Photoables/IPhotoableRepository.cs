using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Domain.Models.Shared;

namespace AnytourApi.Application.Repositories.Polimorfizms.Photoables;

public interface IPhotoableRepository : ICrudRepository<Photoable>;
