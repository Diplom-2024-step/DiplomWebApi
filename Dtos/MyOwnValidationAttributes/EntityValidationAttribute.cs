using System.ComponentModel.DataAnnotations;
using System.Reflection;
using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiForHikka.Dtos.MyOwnValidationAttribute;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class EntityValidationAttribute : ValidationAttribute
{
    private readonly Dictionary<Type, Type> _modelRepositories;

    public EntityValidationAttribute(params Type[] modelTypes)
    {
        _modelRepositories = new Dictionary<Type, Type>();

        foreach (var modelType in modelTypes)
        {
            if (!typeof(IModel).IsAssignableFrom(modelType))
            {
                throw new ArgumentException($"Type {modelType.Name} does not implement IModel", nameof(modelTypes));
            }

            var repositoryType = GetRepositoryType(modelType);

            if (repositoryType == null)
            {
                throw new ArgumentException($"Repository for {modelType.Name} not found", nameof(modelTypes));
            }

            _modelRepositories[modelType] = repositoryType;
        }
    }

    private static Type GetRepositoryType(Type modelType)
    {
        var crudRepositoryType = typeof(ICrudRepository<>);
        var assembly = typeof(ICrudRepository<>).Assembly;
        foreach (var type in assembly.GetTypes())
            if (type.IsInterface && !type.IsGenericType &&
                type.TryGetSubclassType(crudRepositoryType, out var serviceType) &&
                serviceType.GetGenericArguments()[0] == modelType)
                return type;
        return null;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success;

        switch (value)
        {
            case Guid idValue:
                return ValidateSingleId(idValue, validationContext);

            case IEnumerable<Guid> idValues:
                return ValidateMultipleIds((IEnumerable<Guid>)idValues, validationContext);

            default:
                throw new Exception("Entity validation value must be Guid or IEnumerable<Guid>");
        }
    }

    private ValidationResult ValidateSingleId(Guid idValue, ValidationContext validationContext)
    {
        bool found = false;
        string modelName = "";

        foreach (var (modelType, repositoryType) in _modelRepositories)
        {
            var service = (validationContext.GetRequiredService(repositoryType) as dynamic)!;
            var entity = service.Get(idValue);

            if (entity != null)
            {
                found = true;
                modelName = modelType.Name;
                break;
            }
        }

        return found ? ValidationResult.Success :
            new ValidationResult($"{modelName} with id {idValue} doesn't exist");
    }

    private ValidationResult ValidateMultipleIds(IEnumerable<Guid> idValues, ValidationContext validationContext)
    {
        bool found = false;
        string modelName = "";
        List<string> invalidIds = new List<string>();
        foreach (var (modelType, repositoryType) in _modelRepositories)
        {


            foreach (var id in idValues)
            {
                var service = (validationContext.GetRequiredService(repositoryType) as dynamic)!;
                var entity = service.Get(id);

                if (entity != null)
                {
                    found = true;
                    modelName = modelType.Name;
                    break;
                }

                if (!found)
                {
                    invalidIds.Add(id.ToString());
                }
            }
        }

        return found || invalidIds.Count == idValues.Count() ?
            ValidationResult.Success :
            new ValidationResult($"{modelName}s with ids [{string.Join(", ", invalidIds)}] don't exist");
    }
}