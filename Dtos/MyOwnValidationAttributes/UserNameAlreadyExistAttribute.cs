using System.ComponentModel.DataAnnotations;
using Application.Repositories.Users;
using Constants.Models.AppUsers;
using Microsoft.Extensions.DependencyInjection;

namespace Dtos.MyOwnValidationAttributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class UserNameAlreadyExistAttribute : ValidationAttribute
{
    public UserNameAlreadyExistAttribute()
    {
        ErrorMessage = UserStringConstants.UserNameAlreadyExistErrorMessage;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return new ValidationResult(ErrorMessage);

        var username = (string)value;
        var userService = validationContext.GetRequiredService<IUserRepository>();

        return userService.CheckIfUserWithTheUserNameIsAlreadyExist(username)
            ? new ValidationResult(ErrorMessage)
            : ValidationResult.Success!;
    }
}