using Constants.Shared;
using Domain;
using System.ComponentModel;
using TypeGen.Core.TypeAnnotations;

namespace Dtos.Shared;

[ExportTsInterface]
public class SortDto
{
    [DefaultValue(SharedStringConstants.IdName)]
    [TsDefaultValue(SharedStringConstants.IdName)]
    public string Column { get; set; } = SharedStringConstants.IdName;

    [DefaultValue(SortOrder.Asc)] public SortOrder SortOrder { get; set; } = SortOrder.Asc;
}