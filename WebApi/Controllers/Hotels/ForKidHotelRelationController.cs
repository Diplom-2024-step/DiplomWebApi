using AnytourApi.Application.Services.Relations.ForKidHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using WebApiForHikka.WebApi.Shared.RelationController;

namespace AnytourApi.WebApi.Controllers.Hotels;

public class ForKidHotelRelationController(IForKidHotelRelationService relationService, IHttpContextAccessor httpContextAccessor) : 
    RelationController<ForKidHotel, ForKid, Hotel, IForKidHotelRelationService>(relationService, httpContextAccessor);
