using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;

namespace AnytourApi.Application.Services.Relations.FavoriteTours;

public interface IFavoriteTourRelationService : IRelationService<FavoriteTour, Tour, User>;
