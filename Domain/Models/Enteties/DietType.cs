﻿using AnytourApi.Constants.Models.DietTypes;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class DietType : Model
{
    [StringLength(DietTypeNumberConstants.NameLength)]
    public required string Name { get; set; }


    [Range(0, DietTypeNumberConstants.MaxPrice)]
    public required int Price { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
