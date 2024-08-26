using Microsoft.EntityFrameworkCore.Metadata;

namespace AnytourApi.Infrastructure.Filtering;

public record FilteringItem(
    string ReadableName,
    string ActualName,
    IPropertyBase Property
);