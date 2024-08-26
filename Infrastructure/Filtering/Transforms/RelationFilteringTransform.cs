using Microsoft.EntityFrameworkCore.Metadata;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.Infrastructure.Extensions;

namespace AnytourApi.Infrastructure.Filtering.Transforms;

public class RelationFilteringTransform : IFilteringTransform
{
    public IEnumerable<IEnumerable<FilteringItem>> Transform(IEntityType entityType,
        IEnumerable<IEnumerable<FilteringItem>> items)
    {
        return items.Select(i => i.Select(p =>
        {
            if (!p.Property.DeclaringType.ClrType.TryGetSubclassType(typeof(RelationModel<,>), out var relationType))
                return p;

            var firstModel = relationType.GetGenericArguments()[0];
            var secondModel = relationType.GetGenericArguments()[1];

            return p with
            {
                ReadableName = p.ReadableName switch
                {
                    "First" => firstModel.Name,
                    "Second" => firstModel == secondModel ? $"Second{secondModel.Name}" : secondModel.Name,
                    _ => p.ReadableName
                }
            };
        }));
    }
}