using AnytourApi.Application.Repositories.Users;
using AnytourApi.Constants.Models.AppUsers;
using AnytourApi.Domain.Models;
using AnytourApi.EfPersistence.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace AnytourApi.EfPersistence.Repositories;

public class UserRepository(
    AppDbContext dbContext,
    UserManager<User> userManager
) : CrudRepository<User>(dbContext), IUserRepository
{


    public override async Task UpdateAsync(User model, CancellationToken cancellationToken)
    {
        var entity = await DbContext.Set<User>().FirstOrDefaultAsync(e => e.Id == model.Id, cancellationToken);
        if (entity is null)
            return;

        entity.BirthDate = model.BirthDate;
        entity.CityName = model.CityName;
        entity.PhoneNumber = model.PhoneNumber;
        entity.UserName = model.UserName;
        entity.IconNumber = model.IconNumber;

        await DbContext.SaveChangesAsync(cancellationToken);
    }
    public async Task<User?> AuthenticateUserAsync(string email, string password, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user != null && await userManager.CheckPasswordAsync(user, password)) return user;
        return null;
    }

    public async Task<User?> AuthenticateUserWithAdminRoleAsync(string email, string password,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user != null && await userManager.CheckPasswordAsync(user, password) &&
            await userManager.IsInRoleAsync(user, UserStringConstants.AdminRole)) return user;
        return null;
    }

    public override async Task<Guid> AddAsync(User model, CancellationToken cancellationToken)
    {

        model.EmailConfirmed = true;
        var result = await userManager.CreateAsync(model, model.PasswordHash!);
        if (!result.Succeeded)
            // !!!!!!!! Improve error handling
            throw new AggregateException(result.Errors.Select(e => new Exception(e.Description)));

        return model.Id;
    }

    public override Guid Add(User model)
    {

        var result = userManager.CreateAsync(model, model.PasswordHash!);

        return model.Id;
    }

    public async Task<bool> CheckIfUserWithTheEmailIsAlreadyExistAsync(string email,
        CancellationToken cancellationToken)
    {
        var user = await DbContext.Set<User>().FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        if (user == null) return false;
        return true;
    }

    public bool CheckIfUserWithTheEmailIsAlreadyExist(string email)
    {
        var user = DbContext.Set<User>().FirstOrDefault(u => u.Email == email);
        if (user == null) return false;
        return true;
    }

    public async Task<bool> CheckIfUserWithTheUserNameIsAlreadyExistAsync(string username,
        CancellationToken cancellationToken)
    {
        return await DbContext.Set<User>().AnyAsync(u => u.UserName == username, cancellationToken);
    }

    public bool CheckIfUserWithTheUserNameIsAlreadyExist(string username)
    {
        return DbContext.Set<User>().Any(u => u.UserName == username);
    }

    public async Task<string> AddUserWithEmailAsync(User model, CancellationToken cancellationToken)
    {
        var token = CreateRandomToken();

        model.EmailConfirmed = false;
        model.ConfirmingCode = token;
        var result = await userManager.CreateAsync(model, model.PasswordHash!);
        if (!result.Succeeded)
            // !!!!!!!! Improve error handling
            throw new AggregateException(result.Errors.Select(e => new Exception(e.Description)));

        return token;
    }

    public async Task<bool> ConfirmEmailAsync(string email, string code, CancellationToken cancellationToken) 
    {
        var user = await DbContext.Set<User>().FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

        if (user == null || user.ConfirmingCode != code) return false;

        user.EmailConfirmed = true;

        await DbContext.SaveChangesAsync(cancellationToken);

        return true;
    }

    private string CreateRandomToken()
    {
        return Convert.ToHexString(RandomNumberGenerator.GetBytes(3));
    }
}