using System.Text.Json.Serialization;

namespace AnytourApi.Domain.ForSort;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SortOrder
{
    Asc,
    Desc
}