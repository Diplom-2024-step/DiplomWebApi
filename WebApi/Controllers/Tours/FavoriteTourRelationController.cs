using AnytourApi.Application.Services.Relations.FavoriteTours;
using AnytourApi.Constants.Controller;
using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using Microsoft.AspNetCore.Authorization;
using WebApiForHikka.WebApi.Shared.RelationController;

namespace AnytourApi.WebApi.Controllers.Tours;


[AllowAnonymous]
public class FavoriteTourRelationController(IFavoriteTourRelationService relationService, IHttpContextAccessor httpContextAccessor) :
    RelationController<FavoriteTour, Tour, User, IFavoriteTourRelationService>(relationService, httpContextAccessor);
