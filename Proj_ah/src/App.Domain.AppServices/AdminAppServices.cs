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

    public async Task<bool> CreateAdmin(AdminDTO model, CancellationToken cancellationToken)
    => await _adminServices.CreateAdmin(model, cancellationToken);

    public async Task<bool> DeleteAdminById(int id, CancellationToken cancellationToken)

     => await _adminServices.Delete(id, cancellationToken);


    public async Task<List<Admin>> GetAllAdmins(CancellationToken cancellationToken)
    => await _adminServices.GetAll(cancellationToken);

    public async Task<AdminDTO> GetById(int adminId, CancellationToken cancellationToken)
    => await _adminServices.GetById(adminId, cancellationToken);

    public async Task<bool> UpdateAdmin(AdminDTO model, CancellationToken cancellationToken)
    => await _adminServices.Update(model, cancellationToken);


    //public async Task<float> GetWallet(string mail, CancellationToken cancellationToken)
    //{
    //    var adm = await GetAllAdmins(cancellationToken);
    //    float wll = 0;
    //    foreach (var item in adm)
    //    {
    //        if (item.Email == mail)
    //        {
    //            wll = (float)item.Wallet;
    //        }
    //    }
    //    return wll;

    //}


}
