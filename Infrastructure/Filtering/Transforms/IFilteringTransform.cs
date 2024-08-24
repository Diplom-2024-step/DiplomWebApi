using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Filtering.Transforms;

public interface IFilteringTransform
{
    IEnumerable<IEnumerable<FilteringItem>> Transform(IEntityType entityType,
        IEnumerable<IEnumerable<FilteringItem>> items);
}