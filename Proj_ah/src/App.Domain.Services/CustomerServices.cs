using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services;

public class CustomerServices : ICustomerServices
{

    private readonly ICustomerRepository _customerRepository;
    public CustomerServices(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }


    public async Task<bool> CreateCustomer(CustomerDTO model, CancellationToken cancellationToken)
     => await _customerRepository.CreateCustomer(model, cancellationToken);

    public async Task<bool> DeleteCustomerById(int id, CancellationToken cancellationToken)
    => await _customerRepository.DeleteCustomerById(id, cancellationToken);

    public async Task<List<Customer>> GetAllCustomers(CancellationToken cancellationToken)
     => await _customerRepository.GetAllCustomers(cancellationToken);

    public async Task<CustomerDTO>? GetById(int? id, CancellationToken cancellationToken)
    => await _customerRepository.GetById(id, cancellationToken);

    public async Task<bool> UpdateCustomer(CustomerDTO model, CancellationToken cancellationToken)
     => await _customerRepository.UpdateCustomer(model, cancellationToken);
}
