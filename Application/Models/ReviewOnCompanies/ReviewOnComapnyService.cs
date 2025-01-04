using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Users;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.ReviewOnComapnies;
using AutoMapper;

namespace AnytourApi.Application.Services.Models.ReviewOnCompanies;

public class ReviewOnComapnyService(IReviewOnCompanyRepository reviewRepository, IUserRepository userRepository, IMapper mapper)  : CrudService<
    GetReviewOnCompanyDto,
    CreateReviewOnCompanyDto,
    UpdateOnComapnyReviewDto,
    ReviewOnCompany,
    GetReviewOnCompanyDto,
    IReviewOnCompanyRepository>(reviewRepository, mapper), IReviewOnCompanyService
{
    public override async Task<Guid> CreateAsync(CreateReviewOnCompanyDto createDto, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<ReviewOnCompany>(createDto);


        model.User = await userRepository.GetAsync(createDto.UserId, cancellationToken);


        return await Repository.AddAsync(model, cancellationToken);
    }

    public override async Task UpdateAsync(UpdateOnComapnyReviewDto dto, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<ReviewOnCompany>(dto);


        model.User = await userRepository.GetAsync(dto.UserId, cancellationToken);

        await Repository.UpdateAsync(model, cancellationToken);
    }
}
