using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ProcessedOrders;

namespace AnytourApi.Application.Services.Models.ProcessedOrders;

public interface IProcessedOrderService : ICrudService<GetProcessedOrderDto,
    CreateProcessedOrderDto, UpdateProcessedOrderDto, ProcessedOrder, GetProcessedOrderDto>;
