using Infrastructure.Filtering.Transforms;

namespace Infrastructure.Filtering;

public static partial class Filtering
{
    private static IFilteringTransform[] Transforms { get; } = [];
}