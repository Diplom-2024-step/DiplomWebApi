using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Polimorfizms.Photoables;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using AnytourApi.Infrastructure.FileHelper;

namespace AnytourApi.EfPersistence.Repositories.Models;

public class PhotoRepository(AppDbContext dbContext) : CrudRepository<Photo>(dbContext), IPhotoRepository;
