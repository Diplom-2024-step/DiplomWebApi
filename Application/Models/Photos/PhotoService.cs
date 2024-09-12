using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Polimorfizms.Photoables;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Constants.Models.Photos;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Photos;
using AnytourApi.Infrastructure.FileHelper;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.Photos;

public class PhotoService(IPhotoRepository photoRepository, IPhotoableRepository photoableRepository, IFileHelper fileHelper, IMapper mapper) :
    CrudService<GetPhotoDto, CreatePhotoDto, UpdatePhotoDto, Photo, GetPhotoDto, IPhotoRepository>(photoRepository, mapper),
    IPhotoService
{
    public override async Task<Guid> CreateAsync(CreatePhotoDto createDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Photo>(createDto);


        model.PhotoableId = createDto.PhotoableId;

        model.Path =  fileHelper.UploadFileImage(createDto.Photo, PhotoStringConstants.ImagePhotoablePath);

        var HeigthWeidth = fileHelper.GetHeightAndWidthOfImage(createDto.Photo);

        model.Width = HeigthWeidth.width;

        model.Height = HeigthWeidth.height;
        

        return await Repository.AddAsync(model, cancellationToken);
    }

    public override async Task UpdateAsync(UpdatePhotoDto dto, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<Photo>(dto);

        model.PhotoableId = dto.PhotoableId;

        model.Path =  fileHelper.UploadFileImage(dto.Photo, PhotoStringConstants.ImagePhotoablePath);

        var HeigthWeidth = fileHelper.GetHeightAndWidthOfImage(dto.Photo);

        model.Width = HeigthWeidth.width;

        model.Height = HeigthWeidth.height;
        


        await Repository.UpdateAsync(model, cancellationToken);
    }


    public override async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var photo = await Repository.GetAsync(id, cancellationToken);

        if (photo == null) return;

        fileHelper.DeleteFile(photo.Path);

        await Repository.DeleteAsync(id, cancellationToken);
    }

    public async Task<string> GetPathAsync(Guid id, CancellationToken cancellationToken)
    {
        var photo = await Repository.GetAsync(id, cancellationToken);

        return photo.Path;

    }
}

