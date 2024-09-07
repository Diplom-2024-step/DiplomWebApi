﻿using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;

namespace AnytourApi.Application.Services.Relations.ForSportHotels;

public interface IForSportHotelRelationService : IRelationService<ForSportHotel, ForSport, Hotel>;
