using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppServices;

public interface ICustomerAppServices
{
    Task<List<Customer>> GetAllCustomers(CancellationToken cancellationToken);
    Task<bool> DeleteCustomerById(int id, CancellationToken cancellationToken);

}
