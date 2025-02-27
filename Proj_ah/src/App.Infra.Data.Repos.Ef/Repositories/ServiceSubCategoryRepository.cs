using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Repositories;

public class ServiceSubCategoryRepository : IServiceSubCategoryRepository
{
    private readonly AppDbContext _context;

    public ServiceSubCategoryRepository(AppDbContext context)
    {
        _context = context;
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
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public async Task<List<ServiceSubCategoryDTO>> GetAllServices(CancellationToken cancellationToken)
    {
        var result = await _context.ServiceSubCategories
            .Select(model => new ServiceSubCategoryDTO
            {
                Id = model.Id,
                Title = model.Title,
                SubCategory = model.SubCategory,
                SubCategoryId = model.SubCategoryId,
                ImagePath = model.ImagePath,
                CategoryName = model.SubCategory.Title,


            }).ToListAsync(cancellationToken);

        return result;
    }

    public async Task UpdateService(ServiceSubCategoryDTO model, CancellationToken cancellationToken)
    {
        var service = await _context.ServiceSubCategories
            .FirstOrDefaultAsync(s => s.Id == model.Id, cancellationToken);

        service.Id = model.Id;
        service.Title = model.Title;
        service.SubCategoryId = model.SubCategoryId;

        await _context.SaveChangesAsync(cancellationToken);


    }

    public async Task DeleteService(int id, CancellationToken cancellationToken)
    {
        var service = await _context.ServiceSubCategories
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        if (service == null) return;

        service.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
    }
}
