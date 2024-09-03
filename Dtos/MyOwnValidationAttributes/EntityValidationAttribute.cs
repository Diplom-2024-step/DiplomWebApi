using System.ComponentModel.DataAnnotations;
using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiForHikka.Dtos.MyOwnValidationAttribute;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class EntityValidationAttribute<TModel> : ValidationAttribute
    where TModel : class, IModel
{
    private string ModelName { get; } = typeof(TModel).Name;

    private Type RepositoryType { get; } = GetRepositoryType();

    private static Type GetRepositoryType()
    {
        var crudRepositoryType = typeof(ICrudRepository<>);
        var assembly = typeof(ICrudRepository<>).Assembly;
        foreach (var type in assembly.GetTypes())
            if (type is { IsInterface: true, IsGenericType: false } &&
                type.TryGetSubclassType(crudRepositoryType, out var serviceType) &&
                serviceType.GetGenericArguments()[0] == typeof(TModel))
                return type;
        throw new Exception($"Repository for {typeof(TModel).Name} not found");
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success!;
        var service = (validationContext.GetRequiredService(RepositoryType) as ICrudRepository<TModel>)!;

        switch (value)
        {
            case Guid idValue:
                return service.Get(idValue) == null
                    ? new ValidationResult($"{ModelName} with id {idValue} doesn't exist")
                    : ValidationResult.Success!;

            case IEnumerable<Guid> idValues:
            {
                foreach (var id in idValues)
                    if (service.Get(id) == null)
                        return new ValidationResult($"{ModelName} with id {id} doesn't exist");
                return ValidationResult.Success!;
            }
            default:
                throw new Exception("Entity validation value must be Guid or IEnumerable<Guid>");
        }
    }
}