using AnytourApi.Infrastructure.Filtering.Transforms;

namespace AnytourApi.Infrastructure.Filtering;

public static partial class Filtering
{
    private static IFilteringTransform[] Transforms { get; } = [];
}