using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;


namespace AnytourApi.EfPersistence.Repositories.Relations;

public class BeachTypeHotelRelationRepository(AppDbContext dbContext) :
    RelationRepository<BeachTypeHotel, BeachType, Hotel>(dbContext),
    IBeachTypeHotelRelationRepository;
