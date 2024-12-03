using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.RoomTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.RoomTypes;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models;

public class SharedRoomTypeModels : SharedModelsBase, IShareModels<CreateRoomTypeDto, UpdateRoomTypeDto, RoomType>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();

        services.AddScoped<IRoomTypeService, RoomTypeService>();
    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var createDto = SharedRoomTypeModels.GetSampleCreateDto();

        return await serviceProvider.GetService<IRoomTypeService>().CreateAsync(createDto, cancellationToken);

    }

    public static RoomType GetSample()
    {
        return new RoomType()
        {
            Name = "UserName",
            Price = 1
        };
    }

    public static CreateRoomTypeDto GetSampleCreateDto()
    {
        return new CreateRoomTypeDto()
        {
            Name = "test",
            Price = 2
        };
    }

    public static RoomType GetSampleForUpdate()
    {
        return new RoomType()
        {
            Name = "Name123",
            Price= 3
        };
    }

    public static UpdateRoomTypeDto GetSampleUpdateDto()
    {
        return new UpdateRoomTypeDto()
        {
            Name = "test12",
            Price= 4
        };
    }
}
