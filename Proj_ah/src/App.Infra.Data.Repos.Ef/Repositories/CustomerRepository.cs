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

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;
    public CustomerRepository(AppDbContext context)
    {
        _context = context;
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
            return true;
        }
        catch (Exception ex)
        {
            return false;   
        }
    }

    public async Task<bool> DeleteCustomerById(int id, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        if (customer == null) return false;
        try { 
        customer.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public async Task<List<CustomerDTO>> GetAllCustomers(CancellationToken cancellationToken)
    {
        var result = await _context.Customers
            .Select(model => new CustomerDTO
            {
                FirstName = model.FirstName,
                LastName = model.LastName,            
                PhoneNumber = model.PhoneNumber,
                Requests = model.Requests,
                City = model.City,
              
            }).AsNoTracking().ToListAsync(cancellationToken);

        return result;
    }

    public async Task<bool> UpdateCustomer(CustomerDTO model, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers
            .FirstOrDefaultAsync(x => x.Id == model.Id, cancellationToken);

        if (customer == null) return false;

        try
        {
            
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.PhoneNumber = model.PhoneNumber;
            customer.City = model.City;
          

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
            .Select(model => new CustomerDTO
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,                
                City = model.City,
                
            }).AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return customer ?? new CustomerDTO();
    }
}
