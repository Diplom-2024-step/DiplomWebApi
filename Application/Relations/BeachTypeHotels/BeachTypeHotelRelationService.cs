using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Relations.BeachTypeHotels;
using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;

namespace AnytourApi.Application.Services.Relations.BeachTypeHotels;

public class BeachTypeHotelRelationService(IBeachTypeHotelRelationRepository relationRepository) :
    RelationService<BeachTypeHotel, BeachType, Hotel, IBeachTypeHotelRelationRepository>(relationRepository),
    IBeachTypeHotelRelationService;
