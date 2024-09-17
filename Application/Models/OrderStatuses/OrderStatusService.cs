using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.OrderStatuses;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.OrderStatuses;

public class OrderStatusService(IOrderStatusRepository repository, IMapper mapper) :
    CrudService<GetOrderStatusDto, CreateOrderStatusDto, UpdateOrderStatusDto, OrderStatus, GetOrderStatusDto, IOrderStatusRepository>(repository, mapper),
    IOrderStatusService;
