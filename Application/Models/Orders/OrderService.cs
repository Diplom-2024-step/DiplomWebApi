using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Users;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Orders;
using AutoMapper;


namespace AnytourApi.Application.Services.Models.Orders;

public class OrderService(IOrderRepository orderRepository, ITourRepository tourRepository,
    IUserRepository userRepository, IOrderStatusRepository orderStatusRepository, IMapper mapper) :
    CrudService<GetOrderDto, CreateOrderDto, UpdateOrderDto, Order, GetOrderDto, IOrderRepository>(orderRepository, mapper),
    IOrderService
{
    public override async Task<Guid> CreateAsync(CreateOrderDto createDto, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<Order>(createDto);

        model.Tour = await tourRepository.GetAsync(createDto.TourId, cancellationToken);
        model.User = null;
        model.Admin = null;
        model.OrderStatus = await orderStatusRepository.GetAsync(createDto.OrderStatusId, cancellationToken);

        return await Repository.AddAsync(model, cancellationToken);
    }
}
