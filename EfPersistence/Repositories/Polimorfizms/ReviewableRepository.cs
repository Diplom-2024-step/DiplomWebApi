using AnytourApi.Application.Repositories.Polimorfizms.ReviewablePhotoables;
using AnytourApi.Application.Repositories.Polimorfizms.Reviewables;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.EfPersistence.Data;

namespace AnytourApi.EfPersistence.Repositories.Polimorfizms;

public class ReviewableRepository(AppDbContext dbContext) : CrudRepository<Reviewable>(dbContext), IReviewableRepository; 
