using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.TransportationTypes;
using AnytourApi.SharedModels.Shared;

namespace AnytourApi.SharedModels.Models;

public class SharedTransportationTypeModels : SharedModelsBase, IShareModels<CreateTransportationTypeDto, UpdateTransportationTypeDto, TransportationType>
{
    public static TransportationType GetSample()
    {
        return new TransportationType()
        {
            Name = "Name",
        };
    }

    public static CreateTransportationTypeDto GetSampleCreateDto()
    {
        return new CreateTransportationTypeDto()
        {
            Name = "test",
        };
    }

    public static TransportationType GetSampleForUpdate()
    {
        return new TransportationType()
        {
            Name = "Name123"
        };
    }

    public static UpdateTransportationTypeDto GetSampleUpdateDto()
    {
        return new UpdateTransportationTypeDto()
        {
            Name = "test12",
        };
    }
}
