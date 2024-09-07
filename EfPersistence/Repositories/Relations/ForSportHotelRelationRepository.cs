using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;

namespace AnytourApi.EfPersistence.Repositories.Relations;

public class ForSportHotelRelationRepository(AppDbContext dbContext) : 
    RelationRepository<ForSportHotel, ForSport, Hotel>(dbContext),
    IForSportHotelRelationRepository;
