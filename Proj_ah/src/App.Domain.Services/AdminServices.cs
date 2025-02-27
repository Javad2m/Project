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

public class AdminServices : IAdminServices
{
    private readonly IAdminRepository _adminRepository;

    public AdminServices(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<AdminDTO> AdminUpdateInfo(int id, CancellationToken cancellationToken)
     => await _adminRepository.AdminUpdateInfo(id, cancellationToken);

    public async Task<bool> CreateAdmin(AdminDTO model, CancellationToken cancellationToken)
     => await _adminRepository.CreateAdmin(model, cancellationToken);

    public async Task<bool> Delete(int adminId, CancellationToken cancellationToken)
    => await _adminRepository.Delete(adminId, cancellationToken);

    //public async Task<Admin>? GetAdminById(int id, CancellationToken cancellationToken)
    // => await _adminRepository.GetAdminById(id, cancellationToken);

    public async Task<List<Admin>> GetAll(CancellationToken cancellationToken)
      => await _adminRepository.GetAll(cancellationToken);

    public async Task<AdminDTO> GetById(int adminId, CancellationToken cancellationToken)
     => await _adminRepository.GetById(adminId, cancellationToken);

    public async Task<bool> Update(AdminDTO adminUpdateDto, CancellationToken cancellationToken)
    => await _adminRepository.Update(adminUpdateDto, cancellationToken);
}
