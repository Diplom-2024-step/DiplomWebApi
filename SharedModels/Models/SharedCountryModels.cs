using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Countries;
using AnytourApi.SharedModels.Shared;

namespace AnytourApi.SharedModels.Models;

public class SharedCountryModels : SharedModelsBase, IShareModels<CreateCountryDto, UpdateCountryDto, Country>
{
    public static Country GetSample()
    {
        return new Country()
        {
            Icon = "tesfa",
            Name = "UserName",
        };
    }

    public static CreateCountryDto GetSampleCreateDto()
    {
        return new CreateCountryDto()
        {
            Icon = "Test",
            Name = "test",
        };
    }

    public static Country GetSampleForUpdate()
    {
        return new Country()
        {
            Icon = "test123",
            Name = "Name123"
        };
    }

    public static UpdateCountryDto GetSampleUpdateDto()
    {
        return new UpdateCountryDto() 
        {
            Icon = "test12",
            Name = "test12",
        };
    }
}
