using AnytourApi.Application.Services.Relations.ForSportHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using WebApiForHikka.WebApi.Shared.RelationController;

namespace AnytourApi.WebApi.Controllers.Hotels;

public class ForSportHotelRelationController(IForSportHotelRelationService relationService, IHttpContextAccessor httpContextAccessor) :
    RelationController<ForSportHotel, ForSport, Hotel, IForSportHotelRelationService>(relationService, httpContextAccessor);
