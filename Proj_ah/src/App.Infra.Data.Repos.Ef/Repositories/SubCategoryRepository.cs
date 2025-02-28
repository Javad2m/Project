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

public class SubCategoryRepository : ISubCategoryRepository
{
    private readonly AppDbContext _context;
    public SubCategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateSub(SubCategoryDTO model, CancellationToken cancellationToken)
    {
        var newSub = new SubCategory()
        {
            Id = model.Id,
            Title = model.Title,
            CategoryId = model.CategoryId,
            Category = model.Category,
            CreatAt = DateTime.Now,
            IsActive = true,
        };
        try
        {
            await _context.SubCategories.AddAsync(newSub);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task DeleteSub(int id, CancellationToken cancellationToken)
    {
        var sub = await _context.SubCategories
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        if (sub == null) return;

        sub.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<SubCategoryDTO>> GetAllSub(CancellationToken cancellationToken)
    {
        var result = await _context.SubCategories
             .Where(d => d.IsDeleted == false)
           .Select(model => new SubCategoryDTO
           {
               Id = model.Id,
               Title = model.Title,
               CategoryId = model.CategoryId,
               CategoryName = model.Category.Title, 
               CreatAt = model.CreatAt,


           }).ToListAsync(cancellationToken);

        return result;
    }

    public async Task UpdateSub(SubCategoryDTO model, CancellationToken cancellationToken)
    {
        var service = await _context.SubCategories
            .FirstOrDefaultAsync(s => s.Id == model.Id, cancellationToken);

        service.Id = model.Id;
        service.Title = model.Title;
        service.CategoryId = model.CategoryId;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
