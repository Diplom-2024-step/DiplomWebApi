using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Users;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Orders;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;


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

        return await Repository.AddAsync(model, cancellationToken);
    }

    public override async Task<Guid> UpdateAsync(UpdateOrderDto updateOrderDto, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<Order>(updateOrderDto);

        model.Tour = await tourRepository.GetAsync(updateOrderDto.TourId, cancellationToken);
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

        return await Repository.AddAsync(model, cancellationToken);
    }

}
