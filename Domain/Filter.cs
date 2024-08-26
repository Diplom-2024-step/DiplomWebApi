using AnytourApi.Constants.Shared;

namespace AnytourApi.Domain;

public sealed record Filter(
    string SearchTerm = "",
    string Column = SharedStringConstants.IdName,
    bool IsStrict = false);
