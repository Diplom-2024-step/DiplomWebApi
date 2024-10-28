
using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using Microsoft.EntityFrameworkCore;

namespace AnytourApi.EfPersistence.Repositories.Models;

public class PhotoRepository(AppDbContext dbContext) : CrudRepository<Photo>(dbContext), IPhotoRepository
{
    public async Task<ICollection<Photo>> GetAllPhotosForPhotoableId(Guid id, CancellationToken cancellationToken)
    {
        return await DbContext.Set<Photo>().Where(e => e.PhotoableId == id).ToListAsync(cancellationToken);
    }
}
