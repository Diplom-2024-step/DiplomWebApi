﻿using AnytourApi.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace AnytourApi.Dtos.Dto.Users;

[ExportTsInterface]
public class GetUserDto : ModelDto
{
    public required string Email { get; set; }
    public required string[] Roles { get; set; }

    public required string Name { get; set; }
}