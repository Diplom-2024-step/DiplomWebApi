using AnytourApi.Application.Services.Models.ProcessedOrders;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ProcessedOrders;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers.Orders;

public class ProcessedOrderController(IProcessedOrderService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetProcessedOrderDto,
    UpdateProcessedOrderDto,
    CreateProcessedOrderDto,
    IProcessedOrderService,
    ProcessedOrder,
    GetProcessedOrderDto>(CrudService, HttpContextAccessor);
