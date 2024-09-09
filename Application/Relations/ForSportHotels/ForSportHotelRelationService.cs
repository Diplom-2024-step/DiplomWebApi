using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;

namespace AnytourApi.Application.Services.Relations.ForSportHotels;

public class ForSportHotelRelationService(IForSportHotelRelationRepository relationRepository) : 
    RelationService<ForSportHotel, ForSport, Hotel, IForSportHotelRelationRepository>(relationRepository),
    IForSportHotelRelationService;
