using App.Domain.Core.Contracts;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.BaseEntities;
using App.Domain.Core.Entities.Configs;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Access.Dapper;

public class Dapper : IDapper
{
    private readonly SiteSettings _siteSettings;
    private readonly IMemoryCache _memoryCache;

    public Dapper(SiteSettings siteSettings, IMemoryCache memoryCache)
    {
        _siteSettings = siteSettings;
        _memoryCache = memoryCache;
    }

    public async Task<List<Category>> GetAllCategoryDapper(CancellationToken cancellationToken)
    {

        var categories = _memoryCache.Get<List<Category>>("categories");
        if (categories is not null)
        {
            return categories;
        }

        using IDbConnection db = new SqlConnection(_siteSettings.ConnectionStrings.SqlConnection);

        var categoryDictionary = new Dictionary<int, Category>();


        string query = @"
        SELECT c.*, s.*, hs.*
        FROM Categories c
        LEFT JOIN SubCategories s ON c.Id = s.CategoryId
        LEFT JOIN ServiceSubCategories hs ON s.Id = hs.SubCategoryId
        ORDER BY c.CreatedAt, s.CreateAt, hs.CreateAt";

        var categoryList = await db.QueryAsync<Category, SubCategory, ServiceSubCategory, Category>(
            query,
            (category, subCategory, homeService) =>
            {

                if (!categoryDictionary.TryGetValue(category.Id, out var categoryEntry))
                {
                    categoryEntry = category;
                    categoryEntry.SubCategories = new List<SubCategory>();
                    categoryDictionary.Add(category.Id, categoryEntry);
                }

                if (subCategory != null)
                {
                    subCategory.ServiceSubCategories = new List<ServiceSubCategory>();
                    categoryEntry.SubCategories.Add(subCategory);
                }


                if (homeService != null)
                {
                    subCategory?.ServiceSubCategories?.Add(homeService);
                }

                return categoryEntry;
            },
            splitOn: "Id,Id");

        categories = categoryDictionary.Values.ToList();

        _memoryCache.Set("categories", categories, new MemoryCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromDays(1)
        });


        return categories;
    }




    public async Task<List<City>> GetAllCityDapper(CancellationToken cancellationToken)
    {
        var cities = _memoryCache.Get<List<City>>("cities");

        if (cities is not null)
        {
            return cities;
        }

        using IDbConnection db = new SqlConnection(_siteSettings.ConnectionStrings.SqlConnection);
        cities = (List<City>)await db.QueryAsync<City>("SELECT * FROM Cities");

        _memoryCache.Set("cities", cities, new MemoryCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromDays(1)
        });


        return cities;
    }

    public async Task<List<ServiceSubCategoryDTO>> GetAllHomeServiceDapper(CancellationToken cancellationToken)
    {
        var homeServices = _memoryCache.Get<List<ServiceSubCategoryDTO>>("homeServices");

        if (homeServices is not null)
        {
            return homeServices;
        }

        using IDbConnection db = new SqlConnection(_siteSettings.ConnectionStrings.SqlConnection);
        homeServices = (List<ServiceSubCategoryDTO>)await db.QueryAsync<ServiceSubCategoryDTO>(
            @"SELECT h.Id, h.Title, h.SubCategoryId, s.Title AS CategoryName, h.CreateAt
                FROM ServiceSubCategories h
                JOIN SubCategories s ON h.SubCategoryId = s.Id
                ORDER BY h.CreateAt DESC"
        );

        _memoryCache.Set("homeServices", homeServices, new MemoryCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromDays(1)
        });


        return homeServices;
    }

    public async Task<List<SubCategoryDTO>> GetAllSubCategory(CancellationToken cancellationToken)
    {


        if (_memoryCache.TryGetValue("subCategories", out List<SubCategoryDTO> cachedSubCategories))
        {
            return cachedSubCategories;
        }

        const string subCategoryQuery = @"
        SELECT s.Id, s.Title, s.CategoryId, s.CreateAt, c.Title AS CategoryName
        FROM SubCategories s
        INNER JOIN Categories c ON s.CategoryId = c.Id
        ORDER BY s.CreateAt DESC";

        const string homeServiceQuery = @"
        SELECT hs.Id, hs.Title,hs.Description, hs.SubCategoryId
        FROM ServiceSubCategories hs
        WHERE hs.SubCategoryId = @SubCategoryId";

        await using var db = new SqlConnection(_siteSettings.ConnectionStrings.SqlConnection);
        var subCategories = (await db.QueryAsync<SubCategoryDTO>(subCategoryQuery)).ToList();

        foreach (var subCategory in subCategories)
        {
            var homeServices = (await db.QueryAsync<ServiceSubCategory>(homeServiceQuery, new { SubCategoryId = subCategory.Id })).ToList();
            subCategory.ServiceSubCategories = homeServices;
        }

        _memoryCache.Set("subCategories", subCategories, new MemoryCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromMinutes(15)
        });


        return subCategories;
    }
}
