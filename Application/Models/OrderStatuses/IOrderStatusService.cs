using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.OrderStatuses;

namespace AnytourApi.Application.Services.Models.OrderStatuses;

public interface IOrderStatusService : ICrudService<GetOrderStatusDto, CreateOrderStatusDto, UpdateOrderStatusDto, OrderStatus, GetOrderStatusDto>;