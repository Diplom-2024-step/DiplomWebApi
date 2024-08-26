using System.ComponentModel.DataAnnotations;
using AnytourApi.Constants.Controller;
using AnytourApi.Constants.Models.AppUsers;
using AnytourApi.Domain.Models;
using AnytourApi.Dtos.MyOwnValidationAttributes;
using AnytourApi.Dtos.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Users;

[ModelMetadataType(typeof(User))]
[ExportTsInterface]
public class UpdateUserDto : ModelDto
{


    [Required]
    [EmailAddress(ErrorMessage = ControllerStringConstants.EmailIsntFormatedCorrectlyErrorMessage)]
    public required string Email { get; set; }

    [Required]
    [RoleValidation(ErrorMessage = UserStringConstants.RoleDoesntExist)]
    public required string Role { get; set; }

    public required string Name { get; set; }

}