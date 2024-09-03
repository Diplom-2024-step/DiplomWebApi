using AnytourApi.Constants.Models.TransportationTypes;
using AnytourApi.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace AnytourApi.Domain.Models.Enteties;

public class TransportationType : Model
{
    [StringLength(TransportationTypesNumberConstant.NameLength)]
    public required string Name { get; set; }
}
