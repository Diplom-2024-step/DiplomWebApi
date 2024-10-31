using AnytourApi.Application.Services.Relations.OrderActivities;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using WebApiForHikka.WebApi.Shared.RelationController;

namespace AnytourApi.WebApi.Controllers.Orders;

public class OrderActivityRelationController(IOrderActivityRelationService relationService, IHttpContextAccessor httpContextAccessor) : RelationController<OrderActivity, Order, Activity, IOrderActivityRelationService>(relationService, httpContextAccessor);

