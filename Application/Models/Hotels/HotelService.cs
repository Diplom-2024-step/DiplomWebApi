using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Hotels;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.Hotels;

public class HotelService(IHotelRepository hotelsRepository, ICityRepository cityRepository, IMapper mapper) :
    CrudService<GetHotelDto, CreateHotelDto, UpdateHotelDto, Hotel, GetHotelDto, IHotelRepository>(hotelsRepository, mapper),
     IHotelService
{
    public override async Task<Guid> CreateAsync(CreateHotelDto createDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Hotel>(createDto);

        model.City = await cityRepository.GetAsync(createDto.CityId, cancellationToken);

        return await Repository.AddAsync(model, cancellationToken);
    }
}

