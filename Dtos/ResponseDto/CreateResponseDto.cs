using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.ResponseDto;

[ExportTsInterface]
public class CreateResponseDto
{
    public Guid Id { get; set; }
}