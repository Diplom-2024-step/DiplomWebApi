using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Domain.Models.Enteties;

namespace AnytourApi.Application.Repositories.Models;

public interface ICountryRepository : ICrudRepository<Country>;
