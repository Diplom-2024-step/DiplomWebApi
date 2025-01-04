using AnytourApi.Application.Services.Relations.FavoriteHotels;
using AnytourApi.Constants.Controller;
using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using Microsoft.AspNetCore.Authorization;
using WebApiForHikka.WebApi.Shared.RelationController;

namespace AnytourApi.WebApi.Controllers.Hotels;

[AllowAnonymous]
public class FavoriteHotelRelationController(IFavoriteHotelRelationService relationService, IHttpContextAccessor httpContextAccessor) :
    RelationController<FavoriteHotel, Hotel, User, IFavoriteHotelRelationService>(relationService, httpContextAccessor);