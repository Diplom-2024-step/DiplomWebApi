using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.ResponseDto;

[ExportTsInterface]
public class LoginResponseUserDto
{
    public required string Token { get; set; }
}