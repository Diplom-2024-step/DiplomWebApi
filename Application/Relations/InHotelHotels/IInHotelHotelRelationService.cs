using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;

namespace AnytourApi.Application.Services.Relations.InHotelHotels;

public interface IInHotelHotelRelationService : IRelationService<InHotelHotel, InHotel, Hotel>;
