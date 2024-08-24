using TypeGen.Core.TypeAnnotations;

namespace Dtos.ResponseDto;

[ExportTsInterface]
public class LoginResponseUserDto
{
    public required string Token { get; set; }
}