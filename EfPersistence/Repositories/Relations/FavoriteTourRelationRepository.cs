using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.EfPersistence.Data;

namespace AnytourApi.EfPersistence.Repositories.Relations;

public class FavoriteTourRelationRepository(AppDbContext appDbContext) : 
    RelationRepository<FavoriteTour, Tour, User>(appDbContext), IFavoriteTourRelationRepository;
