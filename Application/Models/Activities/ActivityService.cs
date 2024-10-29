using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Photos;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Activities;
using AnytourApi.Dtos.Dto.Models.Hotels;
using AnytourApi.Dtos.Shared;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.Activities;

public class ActivityService(IActivityRepository repository, ICountryRepository countryRepository, IPhotoService photoService, IMapper mapper) :
    CrudService<GetActivityDto, CreateActivityDto, UpdateActivityDto, Activity, GetActivityDto, IActivityRepository>(repository, mapper),
    IActivityService
{

    public override async Task<ReturnPageDto<GetActivityDto>> GetAllAsync(FilterPaginationDto dto, CancellationToken cancellationToken)
    {
        var result = await base.GetAllAsync(dto, cancellationToken);


        foreach (var item in result.Models)
        {
            var photos = await photoService.GetAllPhotosForPhotoableId(item.Id, cancellationToken);

            List<string> ids = new List<string>();

            foreach (var photo in photos)
            {
                ids.Add(photo.Id.ToString());
            }

            item.Urls = ids;
        }

        return result;
    }


    public override async Task<Guid> CreateAsync(CreateActivityDto createDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Activity>(createDto);

        model.Country = await countryRepository.GetAsync(createDto.CountryId, cancellationToken);

        return await Repository.AddAsync(model, cancellationToken);
    }


    public override async Task UpdateAsync(UpdateActivityDto dto, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<Activity>(dto);

        model.Country = await countryRepository.GetAsync(dto.CountryId, cancellationToken);

        await Repository.UpdateAsync(model, cancellationToken);
    }

    public override async Task<GetActivityDto?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var res = await base.GetAsync(id, cancellationToken);

        if (res == null )
        {
            return res;
        }

        var photos = await photoService.GetAllPhotosForPhotoableId(res.Id, cancellationToken);

        List<string> ids = new List<string>();

        foreach (var photo in photos)
        {
            ids.Add(photo.Id.ToString());
        }

        res.Urls = ids;

        return res;
    }

}
