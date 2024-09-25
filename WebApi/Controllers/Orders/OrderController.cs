using AnytourApi.Application.Services.Models.Orders;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Orders;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers.Orders;

public class OrderController(IOrderService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetOrderDto,
    UpdateOrderDto,
    CreateOrderDto,
    IOrderService,
    Order,
    GetOrderDto>(CrudService, HttpContextAccessor);
