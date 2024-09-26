using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Users;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ProcessedOrders;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.ProcessedOrders;

public class ProcessedOrderService(IProcessedOrderRepository processedOrderRepository,
    IOrderRepository orderRepository, IUserRepository userRepository, 
    IOrderStatusRepository orderStatusRepository, IMapper mapper) :
    CrudService<GetProcessedOrderDto, CreateProcessedOrderDto, UpdateProcessedOrderDto,
        ProcessedOrder, GetProcessedOrderDto, IProcessedOrderRepository>(processedOrderRepository, mapper),
    IProcessedOrderService
{
    public override async Task<Guid> CreateAsync(CreateProcessedOrderDto createDto, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<ProcessedOrder>(createDto);

        model.Order = await orderRepository.GetAsync(createDto.OrderId, cancellationToken);
        model.User = null;
        model.Status = await orderStatusRepository.GetAsync(createDto.StatusId, cancellationToken);

        return await Repository.AddAsync(model, cancellationToken);
    }
}
