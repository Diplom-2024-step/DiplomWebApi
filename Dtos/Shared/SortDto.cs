using AnytourApi.Constants.Shared;
using AnytourApi.Domain.ForSort;
using System.ComponentModel;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Shared;

[ExportTsInterface]
public class SortDto
{
    [DefaultValue(SharedStringConstants.IdName)]
    [TsDefaultValue(SharedStringConstants.IdName)]
    public string Column { get; set; } = SharedStringConstants.IdName;

    [DefaultValue(SortOrder.Asc)] public SortOrder SortOrder { get; set; } = SortOrder.Asc;
}