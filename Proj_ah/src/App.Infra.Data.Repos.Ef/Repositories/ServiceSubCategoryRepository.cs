using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;
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


    public ServiceSubCategoryRepository(AppDbContext context, ILogger<ServiceSubCategoryRepository> logger)
    {
        _context = context;
        _logger = logger;
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
        var result = await _context.ServiceSubCategories
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
        _logger.LogInformation("Fetched services", result.Count);
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


    }

    public async Task DeleteService(int id, CancellationToken cancellationToken)
    {
        var service = await _context.ServiceSubCategories
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        if (service == null) return;

        service.IsDeleted = true;
        _logger.LogInformation("Service deleted successfully");

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<ServiceSubCategoryDTO?>> GetAllBySubId(int subCategory, CancellationToken cancellationToken)
    {
        var services = await _context.ServiceSubCategories
              .AsNoTracking()
              .Where(e => e.SubCategoryId == subCategory)
              .Select(e => new ServiceSubCategoryDTO()
              {
                  Id = e.Id,
                  Title = e.Title,
                  ImagePath = e.ImagePath,
                  SubCategoryId = e.SubCategoryId,
                  CategoryName = e.SubCategory.Title,
              }).AsNoTracking().ToListAsync(cancellationToken);
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
