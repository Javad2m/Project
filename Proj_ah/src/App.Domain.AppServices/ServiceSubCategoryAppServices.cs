using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices;

public class ServiceSubCategoryAppServices : IServiceSubCategoryAppServices
{
    private readonly IServiceSubCategoryServices _serviceSubCategoryServices;
    public ServiceSubCategoryAppServices(IServiceSubCategoryServices serviceSubCategoryServices)
    {
        _serviceSubCategoryServices = serviceSubCategoryServices;
    }
    public async Task<bool> CreateService(ServiceSubCategoryDTO model, CancellationToken cancellationToken)
    => await _serviceSubCategoryServices.CreateService(model, cancellationToken);

    public async Task DeleteService(int id, CancellationToken cancellationToken)
     => await _serviceSubCategoryServices.DeleteService(id, cancellationToken);

    public async Task<List<ServiceSubCategoryDTO>> GetAllServices(CancellationToken cancellationToken)
    => await _serviceSubCategoryServices.GetAllServices(cancellationToken);

    public async Task UpdateService(ServiceSubCategoryDTO model, CancellationToken cancellationToken)
    => await _serviceSubCategoryServices.UpdateService(model, cancellationToken);
}
