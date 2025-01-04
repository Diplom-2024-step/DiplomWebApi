using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ReviewOnComapnies;

namespace AnytourApi.Application.Services.Models.ReviewOnCompanies;

public interface IReviewOnCompanyService : ICrudService<GetReviewOnCompanyDto, CreateReviewOnCompanyDto, UpdateOnComapnyReviewDto, ReviewOnCompany, GetReviewOnCompanyDto>;
