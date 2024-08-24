using Constants.Shared;

namespace Domain;

public sealed record Filter(
    string SearchTerm = "",
    string Column = SharedStringConstants.IdName,
    bool IsStrict = false);
