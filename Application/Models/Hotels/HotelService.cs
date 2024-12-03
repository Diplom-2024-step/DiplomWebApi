using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.Photos;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Hotels;
using AnytourApi.Dtos.Shared;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.Hotels;

public class HotelService(IHotelRepository hotelsRepository, ICityRepository cityRepository, 
    IInHotelRepository inHotelRepository, IForSportRepository forSportRepository, 
    IBeachTypeRepository beachTypeRepository, IRoomTypeRepository roomTypeRepository,
    IInRoomRepository inRoomRepository, IForKidsRepository forKidRepository,
    IDietTypeRepository dietTypeRepository, IPhotoService photoService, IMapper mapper) :
    CrudService<GetHotelDto, CreateHotelDto, UpdateHotelDto, Hotel, GetHotelDto, IHotelRepository>(hotelsRepository, mapper),
     IHotelService
{

    public override async Task<ReturnPageDto<GetHotelDto>> GetAllAsync(FilterPaginationDto dto, CancellationToken cancellationToken) 
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


    public override async Task<GetHotelDto?> GetAsync(Guid id, CancellationToken cancellationToken)
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



    public override async Task<Guid> CreateAsync(CreateHotelDto createDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Hotel>(createDto);

        model.City = await cityRepository.GetAsync(createDto.CityId, cancellationToken);

        model.InHotels = await inHotelRepository.GetAllModelsByIdsAsync(createDto.InHotelIds, cancellationToken);

        model.ForSports = await forSportRepository.GetAllModelsByIdsAsync(createDto.ForSportIds, cancellationToken);

        model.BeachTypes = await beachTypeRepository.GetAllModelsByIdsAsync(createDto.BeachTypeIds, cancellationToken);

        model.RoomTypes = await roomTypeRepository.GetAllModelsByIdsAsync(createDto.RoomTypeIds, cancellationToken);

        model.InRooms = await inRoomRepository.GetAllModelsByIdsAsync(createDto.InRoomIds, cancellationToken);

        model.ForKids = await forKidRepository.GetAllModelsByIdsAsync(createDto.ForKidIds, cancellationToken);

        model.DietTypes = await dietTypeRepository.GetAllModelsByIdsAsync(createDto.DietTypeIds, cancellationToken);

        return await Repository.AddAsync(model, cancellationToken);
    }


    public override async Task UpdateAsync(UpdateHotelDto updateHotelDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Hotel>(updateHotelDto);

        model.City = await cityRepository.GetAsync(updateHotelDto.CityId, cancellationToken);

        model.InHotels = await inHotelRepository.GetAllModelsByIdsAsync(updateHotelDto.InHotelIds, cancellationToken);

        model.ForSports = await forSportRepository.GetAllModelsByIdsAsync(updateHotelDto.ForSportIds, cancellationToken);

        model.BeachTypes = await beachTypeRepository.GetAllModelsByIdsAsync(updateHotelDto.BeachTypesIds, cancellationToken);

        model.RoomTypes = await roomTypeRepository.GetAllModelsByIdsAsync(updateHotelDto.RoomTypeIds, cancellationToken);

        model.InRooms = await inRoomRepository.GetAllModelsByIdsAsync(updateHotelDto.InRoomIds, cancellationToken);

        model.ForKids = await forKidRepository.GetAllModelsByIdsAsync(updateHotelDto.ForKidIds, cancellationToken);

        model.DietTypes = await dietTypeRepository.GetAllModelsByIdsAsync(updateHotelDto.DietTypeIds, cancellationToken);

        await Repository.UpdateAsync(model, cancellationToken);
    }
}

