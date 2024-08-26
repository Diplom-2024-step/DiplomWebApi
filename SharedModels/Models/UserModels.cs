using Domain.Models;
using SharedModels.Shared;

namespace SharedModels.Models;

public class UserModels : SharedModels, IShareModels<User>
{
    public static User GetSample()
    {
        return new User()
        {
            Email = "test@gmail.com",
            UserName = "Test",
            PasswordHash = "test",

        };

    }

    public static User GetSampleForUpdate()
    {
        return new User()
        {
            Email = "test1@gmail.com",
            UserName = "Test",
            PasswordHash = "test",
        };
    }
}
