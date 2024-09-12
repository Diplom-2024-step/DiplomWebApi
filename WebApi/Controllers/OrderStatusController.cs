using AnytourApi.Application.Services.Models.OrderStatuses;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.OrderStatuses;
using AnytourApi.WebApi.Shared;

namespace DiplomWebApi.WebApi.Controllers;
public class OrderStatusController(IOrderStatusService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetOrderStatusDto,
    UpdateOrderStatusDto,
    CreateOrderStatusDto,
    IOrderStatusService,
    OrderStatus,
    GetOrderStatusDto>(CrudService, HttpContextAccessor);