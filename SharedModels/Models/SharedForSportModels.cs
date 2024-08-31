using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ForSports;
using AnytourApi.SharedModels.Shared;

namespace AnytourApi.SharedModels.Models;

public class SharedForSportModels : SharedModelsBase, IShareModels<CreateForSportDto, UpdateForSportDto, ForSport>
{
    public static ForSport GetSample()
    {
        return new ForSport()
        {
            Name = "Name",
        };
    }

    public static CreateForSportDto GetSampleCreateDto()
    {
        return new CreateForSportDto()
        {
            Name = "test99",
        };
    }

    public static ForSport GetSampleForUpdate()
    {
        return new ForSport()
        {
            Name = "Name1234"
        };
    }

    public static UpdateForSportDto GetSampleUpdateDto()
    {
        return new UpdateForSportDto()
        {
            Name = "test125",
        };
    }
}

