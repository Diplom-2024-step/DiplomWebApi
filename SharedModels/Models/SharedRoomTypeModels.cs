using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.RoomTypes;
using AnytourApi.SharedModels.Shared;

namespace AnytourApi.SharedModels.Models;

public class SharedRoomTypeModels : SharedModelsBase, IShareModels<CreateRoomTypeDto, UpdateRoomTypeDto, RoomType>
{
    public static RoomType GetSample()
    {
        return new RoomType()
        {
            Name = "UserName",
        };
    }

    public static CreateRoomTypeDto GetSampleCreateDto()
    {
        return new CreateRoomTypeDto()
        {
            Name = "test",
        };
    }

    public static RoomType GetSampleForUpdate()
    {
        return new RoomType()
        {
            Name = "Name123"
        };
    }

    public static UpdateRoomTypeDto GetSampleUpdateDto()
    {
        return new UpdateRoomTypeDto()
        {
            Name = "test12",
        };
    }
}
