using System.ComponentModel.DataAnnotations;
using Constants.Controller;
using Constants.Models.AppUsers;
using Domain.Models;
using Dtos.MyOwnValidationAttributes;
using Dtos.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TypeGen.Core.TypeAnnotations;

namespace Dtos.Dto.Users;

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