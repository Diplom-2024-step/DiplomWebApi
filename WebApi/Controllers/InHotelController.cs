using AnytourApi.Application.Services.Models.InHotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.InHotels;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers;

public class InHotelController(IInHotelService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetInHotelDto,
    UpdateInHotelDto,
    CreateInHotelDto,
    IInHotelService,
    InHotel,
    GetInHotelDto>(CrudService, HttpContextAccessor);
