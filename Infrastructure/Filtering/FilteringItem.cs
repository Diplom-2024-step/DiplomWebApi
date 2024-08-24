using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Filtering;

public record FilteringItem(
    string ReadableName,
    string ActualName,
    IPropertyBase Property
);