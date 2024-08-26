﻿using AnytourApi.Constants.Controller;
using AnytourApi.Constants.Models.AppUsers;
using AnytourApi.Dtos.MyOwnValidationAttributes;
using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Users;

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