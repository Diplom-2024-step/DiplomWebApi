using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;

namespace AnytourApi.EfPersistence.Repositories.Relations;

public class RoomTypeHotelRelationRepository(AppDbContext dbContext) :
    RelationRepository<RoomTypeHotel, RoomType, Hotel>(dbContext),
    IRoomTypeHotelRelationRepository;
