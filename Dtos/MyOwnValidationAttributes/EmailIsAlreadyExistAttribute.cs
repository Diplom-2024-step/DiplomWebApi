using System.ComponentModel.DataAnnotations;
using AnytourApi.Application.Repositories.Users;
using AnytourApi.Constants.Models.AppUsers;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.Dtos.MyOwnValidationAttributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class EmailIsAlreadyExistAttribute : ValidationAttribute
{
    public EmailIsAlreadyExistAttribute()
    {
        ErrorMessage = UserStringConstants.UserEmailAlreadyExistErrorMessage;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return new ValidationResult(ErrorMessage);

        var email = (string)value;
        var userService = validationContext.GetRequiredService<IUserRepository>();

        return userService.CheckIfUserWithTheEmailIsAlreadyExist(email)
            ? new ValidationResult(ErrorMessage)
            : ValidationResult.Success!;
    }
}