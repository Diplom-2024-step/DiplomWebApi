using AnytourApi.Application.Services.Relations.DietTypeHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using WebApiForHikka.WebApi.Shared.RelationController;

namespace AnytourApi.WebApi.Controllers.Hotels;

public class DietTypeHotelRelationController(IDietTypeHotelRelationService relationService, IHttpContextAccessor httpContextAccessor) :
    RelationController<DietTypeHotel, DietType, Hotel, IDietTypeHotelRelationService>(relationService, httpContextAccessor);