using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Services;

public interface ICustomerServices
{
    Task<bool> CreateCustomer(CustomerDTO model, CancellationToken cancellationToken);
    Task<bool> DeleteCustomerById(int id, CancellationToken cancellationToken);
    Task<List<CustomerDTO>> GetAllCustomers(CancellationToken cancellationToken);
    Task<bool> UpdateCustomer(CustomerDTO model, CancellationToken cancellationToken);

    Task<CustomerDTO>? GetById(int? id, CancellationToken cancellationToken);
}
