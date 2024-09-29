using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;

namespace AnytourApi.Application.Services.Relations.InRoomHotels;
public class InRoomHotelRelationService(IInRoomHotelRelationRepository relationRepository) :
    RelationService<InRoomHotel, InRoom, Hotel, IInRoomHotelRelationRepository>(relationRepository), 
    IInRoomHotelRelationService;
