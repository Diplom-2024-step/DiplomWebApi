using AnytourApi.Application.Services.Relations.BeachTypeHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using WebApiForHikka.WebApi.Shared.RelationController;

namespace AnytourApi.WebApi.Controllers.Hotels;

public class BeachTypeHotelRelationController(IBeachTypeHotelRelationService relationService, IHttpContextAccessor httpContextAccessor) :
    RelationController<BeachTypeHotel, BeachType, Hotel, IBeachTypeHotelRelationService>(relationService, httpContextAccessor);

