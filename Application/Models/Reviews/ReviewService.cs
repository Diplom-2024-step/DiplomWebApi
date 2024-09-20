using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Polimorfizms.ReviewablePhotoables;
using AnytourApi.Application.Repositories.Polimorfizms.Reviewables;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Constants.Models.Reviews;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Reviews;
using AnytourApi.Dtos.Dto.Models.Reviews;
using AnytourApi.Infrastructure.FileHelper;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.Reviews;

public class ReviewService(IReviewRepository reviewRepository, IMapper mapper)  : CrudService<
    GetReviewDto,
    CreateReviewDto,
    UpdateReviewDto,
    Review,
    GetReviewDto,
    IReviewRepository>(reviewRepository, mapper), IReviewService
{
    public override async Task<Guid> CreateAsync(CreateReviewDto createDto, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<Review>(createDto);


        model.ReviewablePhotoableId = createDto.ReviewablePhotoableId;


        return await Repository.AddAsync(model, cancellationToken);
    }

    public override async Task UpdateAsync(UpdateReviewDto dto, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<Review>(dto);

        model.ReviewablePhotoableId = dto.ReviewablePhotoableId;


        await Repository.UpdateAsync(model, cancellationToken);
    }
}
