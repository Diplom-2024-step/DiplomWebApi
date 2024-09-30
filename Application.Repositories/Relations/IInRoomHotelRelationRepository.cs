﻿using AnytourApi.Application.Repositories.Shared.Relation;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;

namespace AnytourApi.Application.Repositories.Relations;

public interface IInRoomHotelRelationRepository : IRelationRepository<InRoomHotel, InRoom, Hotel>;