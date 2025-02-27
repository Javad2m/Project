using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppServices;

public interface IAdminAppServices
{
    Task<bool> CreateAdmin(AdminDTO model, CancellationToken cancellationToken);
    Task<bool> DeleteAdminById(int id, CancellationToken cancellationToken);
    Task<List<Admin>> GetAllAdmins(CancellationToken cancellationToken);
    Task<bool> UpdateAdmin(AdminDTO model, CancellationToken cancellationToken);

    Task<AdminDTO> GetById(int adminId, CancellationToken cancellationToken);

    //Task<float> GetWallet(string mail, CancellationToken cancellationToken);

    //Task<int> AdminCount(CancellationToken cancellationToken);
}
