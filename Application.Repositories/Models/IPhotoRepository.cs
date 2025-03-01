﻿using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Domain.Models.Enteties;

namespace AnytourApi.Application.Repositories.Models;

public interface IPhotoRepository : ICrudRepository<Photo> 
{

    public Task<ICollection<Photo>> GetAllPhotosForPhotoableId(Guid id, CancellationToken cancellationToken);
}
