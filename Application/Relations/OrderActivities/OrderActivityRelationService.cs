﻿using AnytourApi.Application.Repositories.Relations;
using AnytourApi.Application.Services.Shared.Relation;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;

namespace AnytourApi.Application.Services.Relations.OrderActivities;

public class OrderActivityRelationService(IOrderActivityRelationRepository relationRepository) :
    RelationService<OrderActivity, Order, Activity, IOrderActivityRelationRepository>(relationRepository),
    IOrderActivityRelationService;
