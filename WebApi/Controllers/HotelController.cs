using AnytourApi.Application.Services.Models.Hotels;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Hotels;
using AnytourApi.WebApi.Shared;

namespace AnytourApi.WebApi.Controllers;

public class HotelController(IHotelService CrudService, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetHotelDto,
    UpdateHotelDto,
    CreateHotelDto,
    IHotelService,
    Hotel,
    GetHotelDto>(CrudService, HttpContextAccessor);
