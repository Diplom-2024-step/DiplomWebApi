using AnytourApi.Application.Repositories.Models;
using AnytourApi.Application.Repositories.Shared;
using AnytourApi.Domain.ForFilter;
using AnytourApi.Domain.ForSort;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;
using Microsoft.EntityFrameworkCore;

namespace AnytourApi.EfPersistence.Repositories.Models;

public class TourRepository(AppDbContext dbContext) : CrudRepository<Tour>(dbContext), ITourRepository

{

    public override async Task<PaginatedCollection<Tour>> GetAllAsync(FilterPagination dto,
               CancellationToken cancellationToken)
    {
        var skip = (dto.PageNumber - 1) * dto.PageSize;
        var take = dto.PageSize;


        var query = DbContext.Set<Tour>().AsQueryable();




        foreach (var i in dto.Filters)
        {
            List<string> countiesIds = new List<string>();

            foreach (var j in i)
            {
                if (j.Column == "Hotel.City.Country.Id")
                {
                    //query = query.Where(e => e.Hotel.City.Country.Id.ToString() == j.SearchTerm);
                    countiesIds.Add(j.SearchTerm);
                    dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                }

                if (j.Column == "PriceUSD")
                {
                    if (j.FilterType == FilterType.SmallerOrEqual)
                    {
                        query = query.Where(e => e.PriceUSD <= int.Parse(j.SearchTerm));
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                    else if (j.FilterType == FilterType.BiggerOrEqual)
                    {
                        query = query.Where(e => e.PriceUSD >= int.Parse(j.SearchTerm));
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                    else if (j.FilterType == FilterType.Smaller)
                    {
                        query = query.Where(e => e.PriceUSD < int.Parse(j.SearchTerm));
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                    else if (j.FilterType == FilterType.Bigger)
                    {
                        query = query.Where(e => e.PriceUSD > int.Parse(j.SearchTerm));
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                }

                if (j.Column == "Hotel.InHotels.Id")
                {
                    if (j.FilterType == FilterType.Strict)
                    {
                        query = query.Where(e => e.Hotel.InHotels.FirstOrDefault(item => item.Id.ToString() == j.SearchTerm) != null);
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                }
                if (j.Column == "RoomType.Id")
                {
                    if (j.FilterType == FilterType.Strict)
                    {
                        query = query.Where(e => e.RoomType.Id.ToString() == j.SearchTerm);
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                }

                if (j.Column == "Hotel.BeachTypes.Id")
                {
                    if (j.FilterType == FilterType.Strict)
                    {
                        query = query.Where(e => e.Hotel.BeachTypes.FirstOrDefault(item => item.Id.ToString() == j.SearchTerm) != null);
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                }

                if (j.Column == "DietType.Id")
                {
                    if (j.FilterType == FilterType.Strict)
                    {
                        query = query.Where(e => e.DietType.Id.ToString() == j.SearchTerm);
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                }

                if (j.Column == "HowManyKids")
                {
                    if (j.FilterType == FilterType.Strict)
                    {
                        query = query.Where(e => e.HowManyKids.ToString() == j.SearchTerm);
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }

                }

                if (j.Column == "HowManyAdults")
                {
                    if (j.FilterType == FilterType.Strict)
                    {
                        query = query.Where(e => e.HowManyAdults.ToString() == j.SearchTerm);
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }

                }

                if (j.Column == "Duration")
                {
                    if (j.FilterType == FilterType.Strict)
                    {
                        query = query.Where(e => e.Duration.ToString() == j.SearchTerm);
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }

                }


            }
            if (countiesIds.Count != 0)
            {
                query = query.Where(e => countiesIds.Contains(e.Hotel.City.Country.Id.ToString()));
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

        return new PaginatedCollection<Tour>(
            models,
            totalItems,
            howManyPages,
            isNextPage,
            isPreviosPage
            );
    }


}
