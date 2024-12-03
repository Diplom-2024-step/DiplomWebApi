using AnytourApi.Constants.Shared;

namespace AnytourApi.Domain.ForFilter;

public sealed record Filter(
    string SearchTerm = "",
    string Column = SharedStringConstants.IdName,
    FilterType FilterType = FilterType.Strict,
    bool Negate = false);