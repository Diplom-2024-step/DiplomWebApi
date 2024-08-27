using AnytourApi.Constants.Models.AppUsers;
using AnytourApi.Domain.Models;
using AnytourApi.Dtos.Dto.Users;
using AnytourApi.SharedModels.Shared;

namespace AnytourApi.SharedModels.Models;

public class SharedUserModels : SharedModelsBase, IShareModels<UserRegistrationDto, UpdateUserDto, User>
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
    public static UserRegistrationDto GetSampleCreateDto()
    {
        return new UserRegistrationDto()
        {
            Email = "test1@gmail.com",
            Password = "test",
            Role = UserStringConstants.AdminRole,
            UserName = "userName"
        };
    }

   
    
    public static UpdateUserDto GetSampleUpdateDto()
    {
        return new UpdateUserDto()
        {
            Email = "test1@gmail.com",
            Name = "Test",
            Role = UserStringConstants.AdminRole,
        };
    }
}
