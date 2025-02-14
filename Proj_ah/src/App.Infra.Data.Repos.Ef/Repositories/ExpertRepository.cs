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

public class ExpertRepository : IExpertRepository
{
    private readonly AppDbContext _context;
    public ExpertRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateExpert(ExpertDTO model, CancellationToken cancellationToken)
    {
        var newExpert = new Expert()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            City = model.City,
            Wallet = 0,
            CreatedAt = DateTime.Now,
        };
        try
        {
            await _context.Experts.AddAsync(newExpert);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task DeleteExpertById(int id, CancellationToken cancellationToken)
    {
        var expert = await _context.Experts
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        if (expert == null) return;

        expert.IsActive = false;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<ExpertDTO>> GetAllExperts(CancellationToken cancellationToken)
    {
        var result = await _context.Experts
            .Select(model => new ExpertDTO
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                City = model.City,
                Skills = model.Skills,


            }).ToListAsync(cancellationToken);

        return result;
    }

    public async Task UpdateExpert(ExpertDTO model, CancellationToken cancellationToken)
    {
        var expert = await _context.Experts
            .Include(s => s.Skills)
            .FirstOrDefaultAsync(x => x.Id == model.Id, cancellationToken);



        expert.FirstName = model.FirstName;
        expert.LastName = model.LastName;

        expert.PhoneNumber = model.PhoneNumber;
        expert.CityId = model.CityId;
        expert.City = model.City;
        expert.Description = model.Description;


        await _context.SaveChangesAsync(cancellationToken);

    }
}
