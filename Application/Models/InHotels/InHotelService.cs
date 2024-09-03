using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Services.Shared;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.InHotels;
using AutoMapper;
using System.ComponentModel.Design;

namespace AnytourApi.Application.Services.Models.InHotels;

public class InHotelService(IInHotelRepository inHotelRepository, IMapper mapper) :
    CrudService<GetInHotelDto, CreateInHotelDto, UpdateInHotelDto, InHotel, GetInHotelDto, IInHotelRepository>(inHotelRepository, mapper),
     IInHotelService;

