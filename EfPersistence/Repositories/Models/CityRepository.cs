using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;

namespace AnytourApi.EfPersistence.Repositories.Models;

public class CityRepository(AppDbContext dbContext) : CrudRepository<City>(dbContext), ICityRepository;

