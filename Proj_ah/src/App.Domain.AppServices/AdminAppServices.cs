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

public class AdminAppServices : IAdminAppServices
{
    private readonly IAdminServices _adminServices;

    public AdminAppServices(IAdminServices adminServices)
    {
        _adminServices = adminServices;
    }

    public async Task CreateAdmin(AdminDTO model, CancellationToken cancellationToken)
    => await _adminServices.CreateAdmin(model, cancellationToken);

    public async Task DeleteAdminById(int id, CancellationToken cancellationToken)

     => await _adminServices.Delete(id, cancellationToken);


    public async Task<List<Admin>> GetAllAdmins(CancellationToken cancellationToken)
    => await _adminServices.GetAll(cancellationToken);

    public async Task UpdateAdmin(AdminDTO model, CancellationToken cancellationToken)
    => await _adminServices.Update(model, cancellationToken);


}
