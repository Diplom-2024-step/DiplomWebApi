using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Models.DietTypes;
using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;

namespace AnytourApi.Application.Services.Relations.DietTypeHotels;

public class DietTypeHotelService(IDietTypeHotelRelationRepository relationRepository) : 
    RelationService<DietTypeHotel, DietType, Hotel, IDietTypeHotelRelationRepository>(relationRepository),
    IDietTypeHotelRelationService;
