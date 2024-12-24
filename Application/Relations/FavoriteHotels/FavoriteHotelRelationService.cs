using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Relations.FavoriteHotels;
using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.Domain.Models;

namespace AnytourApi.Application.Services.Relations.FavoriteHotels;

public class FavoriteHotelRelationService(IFavoriteHotelRelationRepository relationRepository) :
    RelationService<FavoriteHotel, Hotel, User, IFavoriteHotelRelationRepository>(relationRepository),
    IFavoriteHotelRelationService;
