using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repositories;

public interface IAdminRepository
{
    Task<bool> CreateAdmin(AdminDTO model, CancellationToken cancellationToken);
    Task<bool> Update(AdminDTO adminUpdateDto, CancellationToken cancellationToken);

    Task<AdminDTO> AdminUpdateInfo(int id, CancellationToken cancellationToken);

    Task<AdminDTO> GetById(int adminId, CancellationToken cancellationToken);
    Task<List<Admin>> GetAll(CancellationToken cancellationToken);

    Task<bool> Delete(int adminId, CancellationToken cancellationToken);

    //Task<Admin>? GetAdminById(int id, CancellationToken cancellationToken);


}
