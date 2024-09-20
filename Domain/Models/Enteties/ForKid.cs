using AnytourApi.Constants.Models.ForKids;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class ForKid : Model
{
    [StringLength(ForKidsNumberConstants.NameLength)]
    public required string Name { get; set; }
}
