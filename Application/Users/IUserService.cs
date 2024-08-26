using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models;
using AnytourApi.Dtos.Dto.Users;

namespace AnytourApi.Application.Services.Users;

public interface IUserService : ICrudService<
    GetUserDto,
    UserRegistrationDto,
    UpdateUserDto,
    User,
    GetUserDto>
{
    public Task<Guid?> RegisterUserAsync(UserRegistrationDto user, CancellationToken cancellationToken);
    public Task<User?> AuthenticateUserAsync(string email, string password, CancellationToken cancellationToken);

    public Task<User?> AuthenticateUserWithAdminRoleAsync(string email, string password,
        CancellationToken cancellationToken);

    public Task<bool> CheckIfUserWithTheEmailIsAlreadyExistAsync(string email, CancellationToken cancellationToken);
    public bool CheckIfUserWithTheEmailIsAlreadyExist(string email);

    public Task<bool> CheckIfUserWithTheUserNameIsAlreadyExistAsync(string username,
        CancellationToken cancellationToken);

    public bool CheckIfUserWithTheUserNameIsAlreadyExist(string username);
}