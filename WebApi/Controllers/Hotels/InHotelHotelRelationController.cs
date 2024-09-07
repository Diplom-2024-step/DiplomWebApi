using AnytourApi.Application.Services.Relations.InHotelHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using WebApiForHikka.WebApi.Shared.RelationController;

namespace AnytourApi.WebApi.Controllers.Hotels;

public class InHotelHotelRelationController(IInHotelHotelRelationService relationService, IHttpContextAccessor httpContextAccessor) : RelationController<InHotelHotel, InHotel, Hotel, IInHotelHotelRelationService>(relationService, httpContextAccessor);


