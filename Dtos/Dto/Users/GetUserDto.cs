using AnytourApi.Constants.Models.AppUsers;
using AnytourApi.Dtos.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Users;

[ExportTsInterface]
public class GetUserDto : ModelDto
{
    public required string Email { get; set; }
    public required string[] Roles { get; set; }

    public required string UserName { get; set; }

    public required int IconNumber { get; set; }

    public string? CityName { get; set; }

    public DateOnly? BirthDate { get; set; }

    public required List<string> FavoriteHotelsIds { get; set; }
    public required List<string> FavoriteToursIds { get; set; }
}