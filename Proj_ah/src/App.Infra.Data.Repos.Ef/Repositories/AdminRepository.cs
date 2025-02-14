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

public class AdminRepository : IAdminRepository
{

    private readonly AppDbContext _context;
    public AdminRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<bool> CreateAdmin(AdminDTO model, CancellationToken cancellationToken)
    {
        var newAdmin = new Admin()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            CreatedAt = DateTime.Now,
            Wallet = 0
        };
        try
        {
            await _context.Admins.AddAsync(newAdmin);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(AdminDTO adminUpdateDto, CancellationToken cancellationToken)
    {
        var targetModel = await _context.Admins
            .Include(a => a.ApplicationUser)
            .FirstOrDefaultAsync(a => a.Id == adminUpdateDto.Id, cancellationToken);

        targetModel.FirstName = adminUpdateDto.FirstName;
        targetModel.LastName = adminUpdateDto.LastName;
        targetModel.Email = adminUpdateDto.Email;
        targetModel.ApplicationUser.Email = adminUpdateDto.Email;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
    public async Task<AdminDTO> AdminUpdateInfo(int id, CancellationToken cancellationToken)
    {
        var model = await _context.Admins.Select(a => new AdminDTO
        {
            Email = a.ApplicationUser.Email,
            FirstName = a.FirstName,
            LastName = a.LastName,
            Wallet = a.Wallet

        }).AsNoTracking().FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        return model;
    }

    public async Task<List<Admin>> GetAll(CancellationToken cancellationToken)
       => await _context.Admins.AsNoTracking().ToListAsync(cancellationToken);


    public async Task<Admin> GetById(int adminId, CancellationToken cancellationToken)
      => await _context.Admins.AsNoTracking().FirstOrDefaultAsync(a => a.Id == adminId);


    public async Task<bool> Delete(int adminId, CancellationToken cancellationToken)
    {
        var targetAdmin = await GetById(adminId, cancellationToken);
        targetAdmin.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return true;

    }

    public async Task<Admin>? GetAdminById(int id, CancellationToken cancellationToken)
    {
        var admin = await _context.Admins
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

        return admin ?? new Admin();
    }
}
