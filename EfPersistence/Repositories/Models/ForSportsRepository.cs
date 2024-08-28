using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;

namespace AnytourApi.EfPersistence.Repositories.Models;
public class ForSportsRepository(AppDbContext dbContext) : CrudRepository<ForSport>(dbContext), IForSportsRepository;


