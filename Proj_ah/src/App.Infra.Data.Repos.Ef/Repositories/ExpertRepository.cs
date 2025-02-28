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

public class ExpertRepository : IExpertRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<ExpertRepository> _logger;

    public ExpertRepository(AppDbContext context, ILogger<ExpertRepository> logger)
    {
        _context = context;
        _logger = logger;
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
            _logger.LogInformation("Expert Create Succesfully");

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Customer not created Maybe it has already been added Or there is another error {exception}", ex.Message);

            return false;
        }
    }

    public async Task<bool> DeleteExpertById(int id, CancellationToken cancellationToken)
    {
        var expert = await _context.Experts
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        if (expert == null) return false;

        expert.IsDeleted = true;
        _logger.LogInformation("Expert Delete Succesfully");

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<Expert>> GetAllExperts(CancellationToken cancellationToken)
    {
        var result = await _context.Experts
            .Include(a => a.ApplicationUser)
             .Where(d => d.IsDeleted == false)
            .ToListAsync(cancellationToken);
        _logger.LogInformation("Expert GetAll Succesfully");

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

        _logger.LogInformation("Expert Update Succesfully");

        await _context.SaveChangesAsync(cancellationToken);

    }

    public async Task<ExpertDTO>? GetExpertById(int id, CancellationToken cancellationToken)
    {
        var expert = await _context.Experts
            .Select(c => new ExpertDTO
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,

            })
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return expert ?? new ExpertDTO();
    }
}
