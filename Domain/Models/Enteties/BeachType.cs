using AnytourApi.Constants.Models.BeachTypes;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class BeachType : Model
{
    [StringLength(BeachTypeNumberConstants.NameLength)]
    public required string Name { get; set; }
}
