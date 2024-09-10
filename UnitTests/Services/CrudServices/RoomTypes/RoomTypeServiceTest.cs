using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.RoomTypes;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.RoomTypes;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.RoomTypes;

public class RoomTypeServiceTest : SharedServiceTest<
    GetRoomTypeDto,
    CreateRoomTypeDto,
    UpdateRoomTypeDto,
    RoomType,
    GetRoomTypeDto,
    IRoomTypeRepository,
    IRoomTypeService>
{
    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        alternativeServices.AddSingleton(GetDatabaseContext());

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton<IRoomTypeRepository, RoomTypeRepository>();


        return alternativeServices;
    }

    protected override CreateRoomTypeDto GetCreateDtoSample()
    {
        return SharedRoomTypeModels.GetSampleCreateDto();
    }

    protected override UpdateRoomTypeDto GetUpdateDtoSample()
    {
        return SharedRoomTypeModels.GetSampleUpdateDto();
    }

    protected override IRoomTypeService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new RoomTypeService(builder.GetRequiredService<IRoomTypeRepository>(), Mapper);
    }
}
