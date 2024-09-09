﻿using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Photos;

namespace AnytourApi.Application.Services.Models.Photos;

public interface IPhotoService : ICrudService<GetPhotoDto, CreatePhotoDto, UpdatePhotoDto, Photo, GetPhotoDto>;
