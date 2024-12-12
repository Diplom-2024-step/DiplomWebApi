using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Domain.ForFilter;
using AnytourApi.Domain.ForSort;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Dtos.Dto.Models.Hotels;
using AnytourApi.EfPersistence.Data;
using Microsoft.EntityFrameworkCore;

namespace AnytourApi.EfPersistence.Repositories.Models;

public class HotelRepository(AppDbContext dbContext) : CrudRepository<Hotel>(dbContext), IHotelRepository
{

    public override async Task<PaginatedCollection<Hotel>> GetAllAsync(FilterPagination dto,
            CancellationToken cancellationToken)
    {
        var skip = (dto.PageNumber - 1) * dto.PageSize;
        var take = dto.PageSize;


       var query = DbContext.Set<Hotel>().AsQueryable();




        foreach (var i in dto.Filters)
        {
            foreach (var j in i)
            {
                if (j.Column == "City.Country.Id") 
                {
                    query = query.Where(e => e.City.Country.Id.ToString() == j.SearchTerm);
                    dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                }

                if (j.Column == "PricePerNight") 
                {
                    if (j.FilterType == FilterType.SmallerOrEqual)
                    {
                        query = query.Where(e => e.PricePerNight <=  int.Parse(j.SearchTerm));
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                    else if (j.FilterType == FilterType.BiggerOrEqual)
                    {
                        query = query.Where(e => e.PricePerNight >=  int.Parse(j.SearchTerm));
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                    else if (j.FilterType == FilterType.Smaller)
                    {
                        query = query.Where(e => e.PricePerNight <  int.Parse(j.SearchTerm));
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                    else if (j.FilterType == FilterType.Bigger)
                    {
                        query = query.Where(e => e.PricePerNight >  int.Parse(j.SearchTerm));
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                }

                if (j.Column == "InHotels.Id")
                {
                    if (j.FilterType == FilterType.Strict)
                    {
                        query = query.Where(e => e.InHotels.FirstOrDefault(item => item.Id.ToString() == j.SearchTerm) != null);
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                }
                if (j.Column == "RoomTypes.Id")
                {
                    if (j.FilterType == FilterType.Strict)
                    {
                        query = query.Where(e => e.RoomTypes.FirstOrDefault(item => item.Id.ToString() == j.SearchTerm) != null);
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                }

                if (j.Column == "BeachTypes.Id")
                {
                    if (j.FilterType == FilterType.Strict)
                    {
                        query = query.Where(e => e.BeachTypes.FirstOrDefault(item => item.Id.ToString() == j.SearchTerm) != null);
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                }

                if (j.Column == "DietTypes.Id")
                {
                    if (j.FilterType == FilterType.Strict)
                    {
                        query = query.Where(e => e.DietTypes.FirstOrDefault(item => item.Id.ToString() == j.SearchTerm) != null);
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                }


            }
            dto.Filters = dto.Filters.Where(filter => filter.Count() > 0).ToList();

        }


        query = dto.Filters.Aggregate(query,
            (current, filter) => Filter(current, filter));
        var totalItems = await query.CountAsync(cancellationToken);

        var firstSort = dto.Sorts.FirstOrDefault();
        var otherSorts = dto.Sorts.Skip(1).ToArray();
        if (firstSort != null)
        {
            var orderedQuery = Sort(query, firstSort.Column, firstSort.SortOrder == SortOrder.Asc);
            query = otherSorts.Aggregate(orderedQuery,
                (current, sort) => ThenSort(current, sort.Column, sort.SortOrder == SortOrder.Asc));
        }

        var models = await query.Skip(skip).Take(take).ToListAsync(cancellationToken);


        int howManyPages = (int)Math.Ceiling((decimal)totalItems / dto.PageSize);

        bool isNextPage = howManyPages > dto.PageNumber - 1 ? true : false;
        bool isPreviosPage = dto.PageNumber - 1 > 0 ? true : false;

        return new PaginatedCollection<Hotel>(
            models,
            totalItems,
            howManyPages,
            isNextPage,
            isPreviosPage
            );
    }
}
