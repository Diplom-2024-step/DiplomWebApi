using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;

namespace AnytourApi.Application.Services.Relations.ForKidHotels;

public class ForKidHotelRelationService(IForKidHotelRelationRepository relationRepository) : 
    RelationService<ForKidHotel, ForKid, Hotel, IForKidHotelRelationRepository>(relationRepository), 
    IForKidHotelRelationService;
