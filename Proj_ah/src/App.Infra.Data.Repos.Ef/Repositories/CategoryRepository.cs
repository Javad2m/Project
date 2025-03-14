﻿using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<CategoryRepository> _logger;
    private readonly IMemoryCache _memoryCache;

    public CategoryRepository(AppDbContext context, ILogger<CategoryRepository> logger, IMemoryCache memoryCache)
    {
        _context = context;
        _logger = logger;
        _memoryCache = memoryCache;
    }

    public async Task<bool> CreateCategory(CategoryDTO model, CancellationToken cancellationToken)
    {
        var newCategory = new Category()
        {
            Id = model.Id,
            Title = model.Title,
            CreatAt = DateTime.Now,

        };
        try
        {
            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync(cancellationToken);
            _memoryCache.Remove("AllCategories");
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public async Task DeleteCategoryById(int id, CancellationToken cancellationToken)
    {
        var category = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (category == null) return;

        category.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        _memoryCache.Remove("AllCategories");
    }

    public async Task<List<Category>> GetAllCategories(CancellationToken cancellationToken)
    {
        var result = await _context.Categories
            .Where(d => d.IsDeleted == false)
           .AsNoTracking().ToListAsync(cancellationToken);

        _memoryCache.Set("AllCategories", result, TimeSpan.FromMinutes(5));
        _logger.LogInformation("Get All Categories");

        return result;
    }

    public async Task<bool> UpdateCategory(CategoryDTO model, CancellationToken cancellationToken)
    {
        var category = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == model.Id, cancellationToken);

        if (category == null) return false;

        try
        {
            category.Id = model.Id;
            category.Title = model.Title;


            await _context.SaveChangesAsync(cancellationToken);

            _memoryCache.Remove("AllCategories");
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<CategoryDTO> GetCategoryById(int categoryId, CancellationToken cancellationToken)
    {

        var category = await _context.Categories
            .Select(c => new CategoryDTO
            {
                Id = c.Id,
                Title = c.Title,
            }).AsNoTracking().FirstOrDefaultAsync(a => a.Id == categoryId, cancellationToken);


        if (category != null)
        {
            _memoryCache.Set($"Category_{categoryId}", category, TimeSpan.FromMinutes(5));
        }

        return category;
    }
}
