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

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<CustomerRepository> _logger;

    public CustomerRepository(AppDbContext context, ILogger<CustomerRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> CreateCustomer(CustomerDTO model, CancellationToken cancellationToken)
    {
        var newCustomer = new Customer()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            City = model.City,
            CreatedAt = DateTime.Now,
        };
        try
        {
            await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Customer Create Succesfully");

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Customer not created Maybe it has already been added Or there is another error {exception}", ex.Message);

            return false;
        }
    }

    public async Task<bool> DeleteCustomerById(int id, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        if (customer == null) return false;
        try
        {
            customer.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public async Task<List<Customer>> GetAllCustomers(CancellationToken cancellationToken)
    {
        var result = await _context.Customers
             .Include(a => a.ApplicationUser)
             .Where(d => d.IsDeleted == false)
           .AsNoTracking().ToListAsync(cancellationToken);

        return result;
    }

    public async Task<bool> UpdateCustomer(CustomerDTO model, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers
            .Include(a => a.City)
            .FirstOrDefaultAsync(x => x.Id == model.Id, cancellationToken);

        if (customer == null) return false;

        try
        {

            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.CityId = model.CityId;


            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<CustomerDTO>? GetById(int? id, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers
              .Include(a => a.City)
            .Select(model => new CustomerDTO
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                City = model.City,
                CityId = model.CityId,
                Wallet = model.Wallet,

            }).AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return customer ?? new CustomerDTO();
    }

    public async Task<bool> UpdateBalance(int id, float balance, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (customer is null)
        {
            return false;
        }
        customer.Wallet += balance;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
