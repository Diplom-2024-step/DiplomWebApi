using Constants.Shared;

namespace Domain;
public sealed record Sort(
    string Column = SharedStringConstants.IdName,
    SortOrder SortOrder = SortOrder.Asc);