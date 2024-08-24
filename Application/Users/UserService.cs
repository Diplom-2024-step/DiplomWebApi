using Application.Repositories.Users;
using Application.Services.Shared;
using AutoMapper;
using Domain.Models;
using Dtos.Dto.Users;

namespace Application.Services.Users;

public class UserService(IUserRepository repository, IMapper mapper)
    : CrudService<GetUserDto, UserRegistrationDto, UpdateUserDto, User, IUserRepository>(repository, mapper), IUserService
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