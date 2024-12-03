using AnytourApi.Application.Services.Relations.InRoomHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using WebApiForHikka.WebApi.Shared.RelationController;

namespace AnytourApi.WebApi.Controllers.Hotels;

public class InRoomHotelRelationController(IInRoomHotelRelationService relationService, IHttpContextAccessor httpContextAccessor) : 
    RelationController<InRoomHotel, InRoom, Hotel, IInRoomHotelRelationService>(relationService, httpContextAccessor);
