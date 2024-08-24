using Domain.Models.Shared;
using System.Collections;

namespace Application.Repositories.Shared;

public sealed record PaginatedCollection<TModel>(IReadOnlyCollection<TModel> Models, 
    int Total, 
    int HowManyPages,
    bool IsNextPage,
    bool IsPreviosPage)
    : IEnumerable<TModel> where TModel : class, IModel
{
    public IEnumerator<TModel> GetEnumerator()
    {
        // ReSharper disable once NotDisposedResourceIsReturned
        return Models.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}