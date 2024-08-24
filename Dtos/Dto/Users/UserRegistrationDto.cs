using Constants.Controller;
using Constants.Models.AppUsers;
using Dtos.MyOwnValidationAttributes;
using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace Dtos.Dto.Users;

[ExportTsInterface]
public class UserRegistrationDto
{
    [StringLength(AppUserNumberConstants.NameLength, ErrorMessage = UserStringConstants.NameIsTooLongErrorMessage)]
    [UserNameAlreadyExist(ErrorMessage = UserStringConstants.UserNameAlreadyExistErrorMessage)]
    [Required]
    public required string UserName { get; set; }

    [EmailAddress(ErrorMessage = ControllerStringConstants.EmailIsntFormatedCorrectlyErrorMessage)]
    [EmailIsAlreadyExist(ErrorMessage = UserStringConstants.UserEmailAlreadyExistErrorMessage)]
    [Required]
    public required string Email { get; set; }

    [Required]
    [RegularExpression(UserStringConstants.SimplePasswordRegExpression,
        ErrorMessage = UserStringConstants.SimplePasswordErrorMessage)]
    public required string Password { get; set; }

    [Required]
    [RoleValidation(ErrorMessage = UserStringConstants.RoleDoesntExist)]
    public required string Role { get; set; }
}