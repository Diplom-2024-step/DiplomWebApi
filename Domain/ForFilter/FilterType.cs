using System.Text.Json.Serialization;


namespace AnytourApi.Domain.ForFilter;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FilterType
{
    Strict,
    Like,
    InsensitiveLike,
    Contains,
    InsensitiveContains,
    StartsWith,
    EndsWith,
    InsensitiveStartsWith,
    InsensitiveEndsWith,
    Bigger,
    Smaller,
    BiggerOrEqual,
    SmallerOrEqual,
    WebSearch,
    OrderedWebSearch,
    DescendingOrderedWebSearch
}