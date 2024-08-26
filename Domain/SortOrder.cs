using System.Text.Json.Serialization;

namespace AnytourApi.Domain;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SortOrder
{
    Asc,
    Desc
}