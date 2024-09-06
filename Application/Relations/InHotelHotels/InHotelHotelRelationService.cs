using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;

namespace AnytourApi.Application.Services.Relations.InHotelHotels;

public class InHotelHotelRelationService(IInHotelHotelRelationRepository relationRepository) : RelationService<InHotelHotel, InHotel, Hotel, IInHotelHotelRelationRepository>(relationRepository), IInHotelHotelRelationService;
