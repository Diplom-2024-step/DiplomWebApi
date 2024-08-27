using AnytourApi.Constants.Shared;

namespace AnytourApi.Domain.ForSort;
public sealed record Sort(
    string Column = SharedStringConstants.IdName,
    SortOrder SortOrder = SortOrder.Asc);