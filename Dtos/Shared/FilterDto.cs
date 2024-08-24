using Constants.Shared;
using System.ComponentModel;
using TypeGen.Core.TypeAnnotations;

namespace Dtos.Shared;

[ExportTsInterface]
public class FilterDto
{
    [DefaultValue("")]
    [TsDefaultValue("")]
    public string SearchTerm { get; set; } = "";

    [DefaultValue(SharedStringConstants.IdName)]
    [TsDefaultValue(SharedStringConstants.IdName)]
    public string Column { get; set; } = SharedStringConstants.IdName;

    [DefaultValue(false)] public bool IsStrict { get; set; } = false;
}