using TypeGen.Core.TypeAnnotations;

namespace Dtos.ResponseDto;

[ExportTsInterface]
public class CreateResponseDto
{
    public Guid Id { get; set; }
}