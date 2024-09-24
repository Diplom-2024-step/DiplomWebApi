using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Orders;

namespace AnytourApi.Application.Services.Models.Orders;

public interface IOrderService : ICrudService<GetOrderDto, CreateOrderDto, UpdateOrderDto, Order, GetOrderDto>;
