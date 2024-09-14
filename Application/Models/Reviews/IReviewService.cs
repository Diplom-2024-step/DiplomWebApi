using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Reviews;

namespace AnytourApi.Application.Services.Models.Reviews;

public interface IReviewService : ICrudService<GetReviewDto, CreateReviewDto, UpdateReviewDto, Review, GetReviewDto>;
