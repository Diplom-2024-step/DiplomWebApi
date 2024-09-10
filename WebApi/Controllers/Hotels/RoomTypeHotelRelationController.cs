using AnytourApi.Application.Services.Relations.RoomTypeHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using WebApiForHikka.WebApi.Shared.RelationController;

namespace AnytourApi.WebApi.Controllers.Hotels;

public class RoomTypeHotelRelationController(IRoomTypeHotelRelationService relationService, IHttpContextAccessor httpContextAccessor) :
    RelationController<RoomTypeHotel, RoomType, Hotel, IRoomTypeHotelRelationService>(relationService, httpContextAccessor);

