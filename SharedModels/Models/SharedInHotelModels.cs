using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Countries;
using AnytourApi.Dtos.Dto.Models.InHotels;
using AnytourApi.SharedModels.Shared;

namespace AnytourApi.SharedModels.Models;

public class SharedInHotelModels : SharedModelsBase, IShareModels<CreateInHotelDto, UpdateInHotelDto, InHotel>
{
    public static InHotel GetSample()
    {
        return new InHotel()
        {
            Name = "HotelName",
        };
    }

    public static CreateInHotelDto GetSampleCreateDto()
    {
        return new CreateInHotelDto()
        {
            Name = "test",
        };
    }

    public static InHotel GetSampleForUpdate()
    {
        return new InHotel()
        {
            Name = "Name123"
        };
    }

    public static UpdateInHotelDto GetSampleUpdateDto()
    {
        return new UpdateInHotelDto()
        {
            Name = "test12",
        };
    }
}
