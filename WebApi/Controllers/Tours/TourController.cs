﻿using AnytourApi.Application.Services.Models.Tours;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Tours;
using AnytourApi.Dtos.Shared;
using AnytourApi.Infrastructure.LinkFactories;
using AnytourApi.WebApi.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnytourApi.WebApi.Controllers.Tours;

public class TourController(ITourService CrudService, ILinkFactory linkFactory, IHttpContextAccessor HttpContextAccessor) : CrudController<
    GetTourDto,
    UpdateTourDto,
    CreateTourDto,
    ITourService,
    Tour,
    GetTourDto>(CrudService, HttpContextAccessor)
{
    [HttpGet("{id:Guid}")]
    [AllowAnonymous]
    public override async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(
            new ThingsToValidateBase());
        if (errorEndPoint.IsError) return errorEndPoint.GetError();


        var model = await CrudService.GetAsync(id, cancellationToken);
        if (model is null)
            return NotFound();
        List<string> tourPhotos = new List<string>();

        List<string> hotelPhotos = new List<string>();


        foreach (var link in model.Urls)
        {
            tourPhotos.Add(linkFactory.GetImageUrl(Request, link));
        }

        foreach (var link in model.Hotel.Urls)
        {
            hotelPhotos.Add(linkFactory.GetImageUrl(Request, link));
        }

        foreach (var item in model.Activities)
        {
            List<string> activitiesPhotos = new List<string>();

            foreach (var link in item.Urls)
            {
                activitiesPhotos.Add(linkFactory.GetImageUrl(Request, link));
            }
            item.Urls = activitiesPhotos;
        }

        model.Urls = tourPhotos;
        model.Hotel.Urls = hotelPhotos;

        return Ok(model);
    }


    [AllowAnonymous]
    [HttpPost("GetAll")]
    public override async Task<IActionResult> GetAll([FromBody] FilterPaginationDto paginationDto,
        CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(
            new ThingsToValidateBase());


        if (errorEndPoint.IsError) return errorEndPoint.GetError();

        var page = await CrudService.GetAllAsync(paginationDto, cancellationToken);

        foreach (var model in page.Models)
        {
            List<string> tourPhotos = new List<string>();

            List<string> hotelPhotos = new List<string>();


            foreach (var link in model.Urls)
            {
                tourPhotos.Add(linkFactory.GetImageUrl(Request, link));
            }

            foreach (var link in model.Hotel.Urls)
            {
                hotelPhotos.Add(linkFactory.GetImageUrl(Request, link));
            }

            foreach (var item in model.Activities)
            {
                List<string> activitiesPhotos = new List<string>();

                foreach (var link in item.Urls)
                {
                    activitiesPhotos.Add(linkFactory.GetImageUrl(Request, link));
                }
                item.Urls = activitiesPhotos;
            }

            model.Urls = tourPhotos;
            model.Hotel.Urls = hotelPhotos;
        }

        return Ok(page
                   );
    }
}
