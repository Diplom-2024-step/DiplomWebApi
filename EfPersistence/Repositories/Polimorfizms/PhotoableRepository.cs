using AnytourApi.Application.Repositories.Polimorfizms.Photoables;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.EfPersistence.Data;

namespace AnytourApi.EfPersistence.Repositories.Polimorfizms;

public class PhotoableRepository(AppDbContext dbContext) : CrudRepository<Photoable>(dbContext), IPhotoableRepository;
