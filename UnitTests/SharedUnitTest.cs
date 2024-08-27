using AnytourApi.Domain.Models;
using AnytourApi.EfPersistence.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace AnytourApi.UnitTests;

public class SharedUnitTest
{
    protected CancellationToken CancellationToken => new();

    protected AppDbContext GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).EnableSensitiveDataLogging().Options;
        var databaseContext = new AppDbContext(options);
        databaseContext.Database.EnsureCreated();

        return databaseContext;
    }


    protected UserManager<User> GetUserManager(AppDbContext databaseContext)
    {
        var userStore = new UserStore<User, IdentityRole<Guid>, AppDbContext, Guid>(databaseContext);

        var options = new Mock<IOptions<IdentityOptions>>();
        var idOptions = new IdentityOptions();

        //Must be the same in userManager and RoleManage
        //!!!!!!!!!!!!!!!!!!!!! DON'T CHAGE !!!!!!!!!!!!!!!!!!!!!!!!!!!!
        idOptions.User.RequireUniqueEmail = true;
        idOptions.Password.RequireDigit = false;
        idOptions.Password.RequireLowercase = false;
        idOptions.Password.RequireUppercase = false;
        idOptions.Password.RequireNonAlphanumeric = false;
        idOptions.Password.RequiredLength = 2;

        options.Setup(o => o.Value).Returns(idOptions);
        var userValidators = new List<IUserValidator<User>>();
        var validator = new UserValidator<User>();
        userValidators.Add(validator);

        var passValidator = new PasswordValidator<User>();
        var pwdValidators = new List<IPasswordValidator<User>>
        {
            passValidator
        };

        var passwordHasher = new PasswordHasher<User>();
        var keyNormalizer = new UpperInvariantLookupNormalizer();
        var errors = new IdentityErrorDescriber();
        var logger = new Logger<UserManager<User>>(new LoggerFactory());
        var userManager = new UserManager<User>
        (
            userStore,
            options.Object,
            passwordHasher,
            userValidators,
            pwdValidators,
            keyNormalizer,
            errors,
            null!,
            logger
        );

        return userManager;
    }


    protected RoleManager<IdentityRole<Guid>> GetRoleManager(AppDbContext databaseContext)
    {
        var roleStore = new RoleStore<IdentityRole<Guid>, AppDbContext, Guid>(databaseContext);

        var options = new Mock<IOptions<IdentityOptions>>();
        var idOptions = new IdentityOptions();


        //Must be the same in userManager and RoleManage
        //!!!!!!!!!!!!!!!!!!!!! DON'T CHAGE !!!!!!!!!!!!!!!!!!!!!!!!!!!!
        idOptions.User.RequireUniqueEmail = true;
        idOptions.Password.RequireDigit = false;
        idOptions.Password.RequireLowercase = false;
        idOptions.Password.RequireUppercase = false;
        idOptions.Password.RequireNonAlphanumeric = false;
        idOptions.Password.RequiredLength = 2;

        options.Setup(o => o.Value).Returns(idOptions);
        var roleValidators = new List<IRoleValidator<IdentityRole<Guid>>>();
        var validator = new RoleValidator<IdentityRole<Guid>>();
        roleValidators.Add(validator);

        var roleManager = new RoleManager<IdentityRole<Guid>>
        (
            roleStore,
            roleValidators,
            new UpperInvariantLookupNormalizer(),
            new IdentityErrorDescriber(),
            null!
        );

        return roleManager;
    }
}