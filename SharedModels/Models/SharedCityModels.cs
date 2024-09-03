using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Cities;
using AnytourApi.SharedModels.Shared;

namespace AnytourApi.SharedModels.Models;

public class SharedCityModels : SharedModelsBase, IShareModels<CreateCityDto, UpdateCityDto, City>
{
    public static City GetSample()
    {
        return new City()
        {
            Country = SharedCountryModels.GetSample(),
            Latitud = 12.012,
            Longitud = 1.21,
            Name = "city1"
        };
    }

    public static CreateCityDto GetSampleCreateDto()
    {
        return new CreateCityDto()
        {
            CountryId = new Guid(),
            Latitud = 12.012,
            Longitud = 1.21,
            Name = "city1"
        };
    }

    public static City GetSampleForUpdate()
    {
        return new City()
        {
            Country = SharedCountryModels.GetSampleForUpdate(),
            Latitud = 122.2,
            Longitud = 1.1,
            Name = "ty1"
        };
    }

    public static UpdateCityDto GetSampleUpdateDto()
    {
        return new UpdateCityDto()
        {
            CountryId = Guid.NewGuid(),
            Latitud = 12.3,
            Longitud = 13.3,
            Name = "ewq12sa"
        };
    }
}
