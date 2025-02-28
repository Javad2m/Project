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

public class AdminRepository : IAdminRepository
{

    private readonly AppDbContext _context;
    private readonly ILogger<AdminRepository> _logger;

    public AdminRepository(AppDbContext context, ILogger<AdminRepository> logger)
    {
        _context = context;
        _logger = logger;

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
            _logger.LogInformation("Admin Added Succesfully");

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("admin not created Maybe it has already been added Or there is another error {exception}", ex);

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
        _logger.LogInformation(" Update Admin ");

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
        _logger.LogInformation("Update Admin Info");

        return model;
    }

    public async Task<List<Admin>> GetAll(CancellationToken cancellationToken)

       => await _context.Admins
         .Include(a => a.ApplicationUser)
        .Where(d => d.IsDeleted == false)
        .AsNoTracking().ToListAsync(cancellationToken);



    public async Task<AdminDTO> GetById(int adminId, CancellationToken cancellationToken)
    {

        var admin = await _context.Admins
            .Include(e => e.ApplicationUser)
            .Select(a => new AdminDTO
            {
                Id = a.Id,
                Email = a.ApplicationUser.Email,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Wallet = a.Wallet,
                IsDeleted = a.IsDeleted


            }).AsNoTracking().FirstOrDefaultAsync(a => a.Id == adminId);

        _logger.LogInformation("get admin by id ");


        return admin;
    }


    public async Task<bool> Delete(int adminId, CancellationToken cancellationToken)
    {
        var targetAdmin = await _context.Admins.FirstOrDefaultAsync(a => a.Id == adminId);
        targetAdmin.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Admin Delete Succesfully");

        return true;

    }

    //public async Task<Admin>? GetAdminById(int id, CancellationToken cancellationToken)
    //{
    //    var admin = await _context.Admins
    //        .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

    //    return admin ?? new Admin();
    //}
}
