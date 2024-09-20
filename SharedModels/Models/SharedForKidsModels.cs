using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Application.Services.Models.ForKids;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ForKids;
using AnytourApi.EfPersistence.Repositories.Models;
using AnytourApi.SharedModels.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AnytourApi.SharedModels.Models
{
    public class SharedForKidsModels : SharedModelsBase, IShareModels<CreateForKidsDto, UpdateForKidsDto, ForKid>
    {
        public static void AddAllDependencies(IServiceCollection services)
        {
            services.AddScoped<IForKidsRepository, ForKidsRepository>();
            services.AddScoped<IForKidsService, ForKidsService>();
        }

        public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
        {
            var forKids = GetSampleCreateDto();
            return await serviceProvider.GetService<IForKidsService>().CreateAsync(forKids, cancellationToken);
        }

        public static ForKid GetSample()
        {
            return new ForKid
            {
                Name = "ForKidsName"
            };
        }

        public static CreateForKidsDto GetSampleCreateDto()
        {
            return new CreateForKidsDto
            {
                Name = "test"
            };
        }

        public static ForKid GetSampleForUpdate()
        {
            return new ForKid
            {
                Name = "Name123"
            };
        }

        public static UpdateForKidsDto GetSampleUpdateDto()
        {
            return new UpdateForKidsDto
            {
                Name = "test12"
            };
        }
    }
}
