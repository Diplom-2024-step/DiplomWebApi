using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;

namespace AnytourApi.Application.Services.Relations.RoomTypeHotels;

public class RoomTypeHotelRelationService(IRoomTypeHotelRelationRepository relationRepository) :
    RelationService<RoomTypeHotel, RoomType, Hotel, IRoomTypeHotelRelationRepository>(relationRepository),
    IRoomTypeHotelRelationService;

