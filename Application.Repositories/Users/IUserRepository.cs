using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Domain.Models;

namespace AnytourApi.Application.Repositories.Users;

public interface IUserRepository : ICrudRepository<User>
{
    public Task<User?> AuthenticateUserAsync(string email, string password, CancellationToken cancellationToken);

    public Task<User?> AuthenticateUserWithAdminRoleAsync(string email, string password,
        CancellationToken cancellationToken);

    public Task<bool> CheckIfUserWithTheEmailIsAlreadyExistAsync(string email, CancellationToken cancellationToken);
    public bool CheckIfUserWithTheEmailIsAlreadyExist(string email);

    public Task<bool> CheckIfUserWithTheUserNameIsAlreadyExistAsync(string username,
        CancellationToken cancellationToken);

    public bool CheckIfUserWithTheUserNameIsAlreadyExist(string username);

    public Task<string> AddUserWithEmailAsync(User model, CancellationToken cancellationToken);

    public Task<bool> ConfirmEmailAsync(string email, string code, CancellationToken cancellationToken);
}