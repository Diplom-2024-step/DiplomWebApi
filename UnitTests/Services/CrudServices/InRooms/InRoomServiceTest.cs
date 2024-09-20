using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.InRooms;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.InRooms;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Models;
using AnytourApi.UnitTests.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.UnitTests.Services.CrudServices.InRooms
{
    public class InRoomServiceTest : SharedServiceTest<
        GetInRoomDto,
        CreateInRoomDto,
        UpdateInRoomDto,
        InRoom,
        GetInRoomDto,
        IInRoomRepository,
        IInRoomService>
    {
        protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
        {
            alternativeServices.AddSingleton(GetDatabaseContext());
            alternativeServices.AddSingleton(Mapper);
            alternativeServices.AddSingleton<IInRoomRepository, InRoomRepository>();
            return alternativeServices;
        }

        protected override CreateInRoomDto GetCreateDtoSample()
        {
            return SharedInRoomModels.GetSampleCreateDto();
        }

        protected override UpdateInRoomDto GetUpdateDtoSample()
        {
            return SharedInRoomModels.GetSampleUpdateDto();
        }

        protected override IInRoomService GetService(IServiceCollection alternativeServices)
        {
            var builder = alternativeServices.BuildServiceProvider();
            return new InRoomService(builder.GetRequiredService<IInRoomRepository>(), Mapper);
        }
    }
}
