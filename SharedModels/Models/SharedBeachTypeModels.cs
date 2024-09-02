using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.BeachTypes;
using AnytourApi.SharedModels.Shared;

namespace AnytourApi.SharedModels.Models;

public class SharedBeachTypeModels : SharedModelsBase, IShareModels<CreateBeachTypeDto, UpdateBeachTypeDto, BeachType>
{
    public static BeachType GetSample()
    {
        return new BeachType()
        {
            Name = "UserName",
        };
    }

    public static CreateBeachTypeDto GetSampleCreateDto()
    {
        return new CreateBeachTypeDto()
        {
            Name = "test",
        };
    }

    public static BeachType GetSampleForUpdate()
    {
        return new BeachType()
        {
            Name = "Name123"
        };
    }

    public static UpdateBeachTypeDto GetSampleUpdateDto()
    {
        return new UpdateBeachTypeDto()
        {
            Name = "test12",
        };
    }
}
