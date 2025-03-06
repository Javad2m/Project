using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices;

public class CustomerAppServices : ICustomerAppServices
{

    private readonly ICustomerServices _customerServices;

    public CustomerAppServices(ICustomerServices customerServices)
    {
        _customerServices = customerServices;
    }

    public async Task<bool> DeleteCustomerById(int id, CancellationToken cancellationToken)
    => await _customerServices.DeleteCustomerById(id, cancellationToken);

    public async Task<List<Customer>> GetAllCustomers(CancellationToken cancellationToken)
     => await _customerServices.GetAllCustomers(cancellationToken);

    public async Task<CustomerDTO>? GetById(int? id, CancellationToken cancellationToken)
    => await _customerServices.GetById(id, cancellationToken);
}
