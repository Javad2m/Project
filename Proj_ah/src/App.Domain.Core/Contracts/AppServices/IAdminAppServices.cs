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
    Task CreateAdmin(AdminDTO model, CancellationToken cancellationToken);
    Task DeleteAdminById(int id, CancellationToken cancellationToken);
    Task<List<Admin>> GetAllAdmins(CancellationToken cancellationToken);
    Task UpdateAdmin(AdminDTO model, CancellationToken cancellationToken);

    //Task<int> AdminCount(CancellationToken cancellationToken);
}
