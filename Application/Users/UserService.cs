using AnytourApi.Application.Repositories.Users;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Constants.Models.AppUsers;
using AnytourApi.Domain.Models;
using AnytourApi.Dtos.Dto.Users;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AnytourApi.Application.Services.Users;

public class UserService(IUserRepository repository, RoleManager<IdentityRole<Guid>> roleManager, IMapper mapper)
    : CrudService<GetUserDto, UserRegistrationDto, UpdateUserDto, User, GetUserDto, IUserRepository>(repository, mapper), IUserService
{
    public override async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await Repository.GetAsync(id, cancellationToken);

        await Repository.DeleteAsync(id, cancellationToken);
    }

    public async Task<User?> AuthenticateUserAsync(string email, string password, CancellationToken cancellationToken)
    {
        var user = await Repository.AuthenticateUserAsync(email, password, cancellationToken);
        return user;
    }

    public async Task<Guid?> RegisterUserAsync(UserRegistrationDto user, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<User>(user);

        var role = await roleManager.FindByNameAsync(user.Role);
        model.Roles.Add(role!);

        return await Repository.AddAsync(model, cancellationToken);
    }

    public async Task<bool> CheckIfUserWithTheEmailIsAlreadyExistAsync(string email,
        CancellationToken cancellationToken)
    {
        return await Repository.CheckIfUserWithTheEmailIsAlreadyExistAsync(email, cancellationToken);
    }

    public bool CheckIfUserWithTheEmailIsAlreadyExist(string email)
    {
        return Repository.CheckIfUserWithTheEmailIsAlreadyExist(email);
    }

    public async Task<User?> AuthenticateUserWithAdminRoleAsync(string email, string password,
        CancellationToken cancellationToken)
    {
        return await Repository.AuthenticateUserWithAdminRoleAsync(email, password, cancellationToken);
    }

    public async Task<bool> CheckIfUserWithTheUserNameIsAlreadyExistAsync(string username,
        CancellationToken cancellationToken)
    {
        return await Repository.CheckIfUserWithTheUserNameIsAlreadyExistAsync(username, cancellationToken);
    }

    public bool CheckIfUserWithTheUserNameIsAlreadyExist(string username)
    {
        return Repository.CheckIfUserWithTheUserNameIsAlreadyExist(username);
    }
}