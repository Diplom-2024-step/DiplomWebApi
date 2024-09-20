using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Models.InRooms;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.InRooms;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models
{
    public class SharedInRoomModels : SharedModelsBase, IShareModels<CreateInRoomDto, UpdateInRoomDto, InRoom>
    {
        public static void AddAllDependencies(IServiceCollection services)
        {
            services.AddScoped<IInRoomRepository, InRoomRepository>();
            services.AddScoped<IInRoomService, InRoomService>();
        }

        public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
        {
            var inRoom = GetSampleCreateDto();
            return await serviceProvider.GetService<IInRoomService>().CreateAsync(inRoom, cancellationToken);
        }

        public static InRoom GetSample()
        {
            return new InRoom
            {
                Name = "InRoomName"
            };
        }

        public static CreateInRoomDto GetSampleCreateDto()
        {
            return new CreateInRoomDto
            {
                Name = "test"
            };
        }

        public static InRoom GetSampleForUpdate()
        {
            return new InRoom
            {
                Name = "Name123"
            };
        }

        public static UpdateInRoomDto GetSampleUpdateDto()
        {
            return new UpdateInRoomDto
            {
                Name = "test12"
            };
        }
    }
}
