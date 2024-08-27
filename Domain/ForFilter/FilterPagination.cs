using AnytourApi.Constants.Shared;
using AnytourApi.Domain.ForSort;

namespace AnytourApi.Domain.ForFilter;

public sealed record FilterPagination(
    int PageNumber = SharedNumberConstatnts.DefaultPageToStartWith,
    int PageSize = SharedNumberConstatnts.DefaultItemsInOnePage)
{
    public IEnumerable<IEnumerable<Filter>> Filters { get; init; } = [];
    public IEnumerable<Sort> Sorts { get; init; } = [];
}
