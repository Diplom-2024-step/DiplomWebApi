using AnytourApi.Application.Services.Models.Reviews;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Reviews;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers;

public class ReviewController(IReviewService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetReviewDto,
    UpdateReviewDto,
    CreateReviewDto,
    IReviewService,
    Review,
    GetReviewDto>(CrudService, HttpContextAccessor);