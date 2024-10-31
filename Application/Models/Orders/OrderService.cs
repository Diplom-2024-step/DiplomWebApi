using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Users;
using AnytourApi.Application.Services.Models.Activities;
using AnytourApi.Application.Services.Models.Countries;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Orders;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;


namespace AnytourApi.Application.Services.Models.Orders;

public class OrderService(IOrderRepository orderRepository, IHotelRepository hotelRepository,
    IUserRepository userRepository, IOrderStatusRepository orderStatusRepository, ITransportationTypeRepository transportationTypeRepository, ICityRepository cityRepository, IDietTypeRepository dietTypeRepository, IRoomTypeRepository roomTypeRepository, IActivityRepository activityRepository,   IMapper mapper) :
    CrudService<GetOrderDto, CreateOrderDto, UpdateOrderDto, Order, GetOrderDto, IOrderRepository>(orderRepository, mapper),
    IOrderService
{
    public override async Task<Guid> CreateAsync(CreateOrderDto createDto, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<Order>(createDto);

        model.Hotel = await hotelRepository.GetAsync(createDto.HotelId, cancellationToken);
        if (createDto.UserId != null)
        {
            model.User = await userRepository.GetAsync((Guid)createDto.UserId, cancellationToken);
        }
        else
        {
            model.User = null;
        }

        if (createDto.AdminId != null)
        {
            model.Admin = await userRepository.GetAsync((Guid)createDto.AdminId, cancellationToken);
        }
        else
        {
            model.Admin = null;
        }
        model.OrderStatus = await orderStatusRepository.GetAsync(createDto.OrderStatusId, cancellationToken);
        model.TransportationType = await transportationTypeRepository.GetAsync(createDto.TransportationTypeId, cancellationToken);
        model.DietType = await dietTypeRepository.GetAsync(createDto.DietTypeId, cancellationToken);

        model.ToCity = await cityRepository.GetAsync(createDto.ToCityId, cancellationToken);
        model.FromCity = await cityRepository.GetAsync(createDto.FromCityId, cancellationToken);

        model.RoomType = await roomTypeRepository.GetAsync(createDto.RoomTypeId, cancellationToken);

        model.Activities = await activityRepository.GetAllModelsByIdsAsync(createDto.ActivityIds, cancellationToken);

        return await Repository.AddAsync(model, cancellationToken);
    }

    public override async Task UpdateAsync(UpdateOrderDto updateOrderDto, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<Order>(updateOrderDto);

        model.Hotel = await hotelRepository.GetAsync(updateOrderDto.HotelId, cancellationToken);
        if (updateOrderDto.UserId != null)
        {
            model.User = await userRepository.GetAsync((Guid)updateOrderDto.UserId, cancellationToken);
        }
        else
        {
            model.User = null;
        }
        if (updateOrderDto.AdminId != null)
        {
            model.Admin = await userRepository.GetAsync((Guid)updateOrderDto.AdminId, cancellationToken);
        }
        else
        {
            model.Admin = null;
        }
        model.OrderStatus = await orderStatusRepository.GetAsync(updateOrderDto.OrderStatusId, cancellationToken);
        model.TransportationType = await transportationTypeRepository.GetAsync(updateOrderDto.TransportationTypeId, cancellationToken);
        model.DietType = await dietTypeRepository.GetAsync(updateOrderDto.DietTypeId, cancellationToken);

        model.ToCity = await cityRepository.GetAsync(updateOrderDto.ToCityId, cancellationToken);
        model.FromCity = await cityRepository.GetAsync(updateOrderDto.FromCityId, cancellationToken);

        model.RoomType = await roomTypeRepository.GetAsync(updateOrderDto.RoomTypeId, cancellationToken);

        model.Activities = await activityRepository.GetAllModelsByIdsAsync(updateOrderDto.ActivityIds, cancellationToken);

        await Repository.UpdateAsync(model, cancellationToken);
    }

}
