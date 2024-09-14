using AnytourApi.Application.Repositories.Polimorfizms.ReviewablePhotoables;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.EfPersistence.Data;

namespace AnytourApi.EfPersistence.Repositories.Polimorfizms;

public class ReviewablePhotoableRepository(AppDbContext dbContext) : CrudRepository<ReviewablePhotoable>(dbContext), IReviewablePhotoableRepository;
