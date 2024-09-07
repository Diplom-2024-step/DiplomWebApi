﻿using AnytourApi.Constants.Models.RoomTypes;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class RoomType : Model
{
    [StringLength(RoomTypeNumberConstants.NameLength)]
    public required string Name { get; set; }
}