using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Activities;
using AnytourApi.SharedModels.Shared;

namespace AnytourApi.SharedModels.Models;

public class SharedActivityModels : SharedModelsBase, IShareModels<CreateActivityDto, UpdateActivityDto, Activity>
{
    public static Activity GetSample()
    {
        return new Activity()
        {
            Name = "ActivityName",
        };
    }

    public static CreateActivityDto GetSampleCreateDto()
    {
        return new CreateActivityDto()
        {
            Name = "test",
        };
    }

    public static Activity GetSampleForUpdate()
    {
        return new Activity()
        {
            Name = "Name123"
        };
    }

    public static UpdateActivityDto GetSampleUpdateDto()
    {
        return new UpdateActivityDto()
        {
            Name = "test12",
        };
    }
}
