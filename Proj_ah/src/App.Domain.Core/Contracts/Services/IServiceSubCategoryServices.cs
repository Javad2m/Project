using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Services;

public interface IServiceSubCategoryServices
{
    Task<bool> CreateService(ServiceSubCategoryDTO model, CancellationToken cancellationToken);
    Task<List<ServiceSubCategoryDTO>> GetAllServices(CancellationToken cancellationToken);

    Task UpdateService(ServiceSubCategoryDTO model, CancellationToken cancellationToken);

    Task DeleteService(int id, CancellationToken cancellationToken);
}
