using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Hotels;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.Hotels;

public class HotelService(IHotelRepository hotelsRepository, ICityRepository cityRepository, 
    IInHotelRepository inHotelRepository, IForSportRepository forSportRepository, 
    IBeachTypeRepository beachTypeRepository, IRoomTypeRepository roomTypeRepository, IInRoomRepository inRoomRepository, IForKidsRepository forKidRepository,
    IMapper mapper) :
    CrudService<GetHotelDto, CreateHotelDto, UpdateHotelDto, Hotel, GetHotelDto, IHotelRepository>(hotelsRepository, mapper),
     IHotelService
{
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

        return await Repository.AddAsync(model, cancellationToken);
    }
}

