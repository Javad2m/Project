using App.Domain.Core.Contracts.Repositories;
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

public class ServiceSubCategoryRepository : IServiceSubCategoryRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<ServiceSubCategoryRepository> _logger;
    private readonly IMemoryCache _memoryCache;



    public ServiceSubCategoryRepository(AppDbContext context, ILogger<ServiceSubCategoryRepository> logger, IMemoryCache memoryCache)
    {
        _context = context;
        _logger = logger;
        _memoryCache = memoryCache;
    }
    public async Task<bool> CreateService(ServiceSubCategoryDTO model, CancellationToken cancellationToken)
    {
        var newService = new ServiceSubCategory()
        {
            Id = model.Id,
            Title = model.Title,
            SubCategoryId = model.SubCategoryId,
            SubCategory = model.SubCategory,
            CreatAt = DateTime.Now,
            IsActive = true,
        };
        try
        {
            await _context.ServiceSubCategories.AddAsync(newService);
            await _context.SaveChangesAsync(cancellationToken);


            _memoryCache.Remove("AllServices");
            _memoryCache.Remove($"ServicesBySubCategory_{model.SubCategoryId}");
            _logger.LogInformation("Service created successfully: {ServiceId}", newService.Id);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create service: {ServiceId}", newService.Id);

            return false;
        }
    }
    public async Task<List<ServiceSubCategoryDTO>> GetAllServices(CancellationToken cancellationToken)
    {
        if (!_memoryCache.TryGetValue("AllServices", out List<ServiceSubCategoryDTO> result))
        {
            result = await _context.ServiceSubCategories
                .Where(d => d.IsDeleted == false)
                .Select(model => new ServiceSubCategoryDTO
                {
                    Id = model.Id,
                    Title = model.Title,
                    SubCategory = model.SubCategory,
                    SubCategoryId = model.SubCategoryId,
                    ImagePath = model.ImagePath,
                    CategoryName = model.SubCategory.Title,
                }).ToListAsync(cancellationToken);

            _memoryCache.Set("AllServices", result, TimeSpan.FromMinutes(5));
        }

        _logger.LogInformation("Fetched services from cache, total: {Count}", result.Count);
        return result;
    }

    public async Task UpdateService(ServiceSubCategoryDTO model, CancellationToken cancellationToken)
    {
        var service = await _context.ServiceSubCategories
            .FirstOrDefaultAsync(s => s.Id == model.Id, cancellationToken);

        service.Id = model.Id;
        service.Title = model.Title;
        service.SubCategoryId = model.SubCategoryId;
        _logger.LogInformation("Service updated successfully: {ServiceId}", model.Id);

        await _context.SaveChangesAsync(cancellationToken);
        _memoryCache.Remove("AllServices");
        _memoryCache.Remove($"ServicesBySubCategory_{model.SubCategoryId}");


    }

    public async Task DeleteService(int id, CancellationToken cancellationToken)
    {
        var service = await _context.ServiceSubCategories
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        if (service == null) return;

        service.IsDeleted = true;
        _logger.LogInformation("Service deleted successfully");

        await _context.SaveChangesAsync(cancellationToken);
        _memoryCache.Remove("AllServices");
        _memoryCache.Remove($"ServicesBySubCategory_{service.SubCategoryId}");
    }

    public async Task<List<ServiceSubCategoryDTO?>> GetAllBySubId(int subCategory, CancellationToken cancellationToken)
    {
        if (!_memoryCache.TryGetValue($"ServicesBySubCategory_{subCategory}", out List<ServiceSubCategoryDTO> services))
        {
            services = await _context.ServiceSubCategories
                .AsNoTracking()
                .Where(e => e.SubCategoryId == subCategory && !e.IsDeleted)
                .Select(e => new ServiceSubCategoryDTO()
                {
                    Id = e.Id,
                    Title = e.Title,
                    ImagePath = e.ImagePath,
                    SubCategoryId = e.SubCategoryId,
                    CategoryName = e.SubCategory.Title,
                }).ToListAsync(cancellationToken);

            _memoryCache.Set($"ServicesBySubCategory_{subCategory}", services, TimeSpan.FromMinutes(5));
        }

        return services;
    }

    public async Task<ServiceSubCategoryDTO> GetServiceById(int id, CancellationToken cancellationToken)
    {
        var service = await _context.ServiceSubCategories.AsNoTracking().Include(x => x.SubCategory).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (service is null)
        {
            throw new Exception("خدمات  پیدا نشد.");
        }
        return new ServiceSubCategoryDTO
        {
            Id = service.Id,
            Title = service.Title,
            ImagePath = service.ImagePath,
            SubCategoryId = service.SubCategoryId,
            CategoryName = service.SubCategory.Title
        };
    }
}
