﻿using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services;

public class ServiceSubCategoryServices : IServiceSubCategoryServices
{

    private readonly IServiceSubCategoryRepository _repository;

    public ServiceSubCategoryServices(IServiceSubCategoryRepository serviceSubCategoryRepository)
    {
        _repository = serviceSubCategoryRepository;
    }
    public async Task<bool> CreateService(ServiceSubCategoryDTO model, CancellationToken cancellationToken)
      => await _repository.CreateService(model, cancellationToken);

    public async Task DeleteService(int id, CancellationToken cancellationToken)
     => await _repository.DeleteService(id, cancellationToken);

    public async Task<List<ServiceSubCategoryDTO?>> GetAllBySubId(int subCategory, CancellationToken cancellationToken)
    => await _repository.GetAllBySubId(subCategory, cancellationToken);

    public async Task<List<ServiceSubCategoryDTO>> GetAllServices(CancellationToken cancellationToken)
    => await _repository.GetAllServices(cancellationToken);

    public async Task<ServiceSubCategoryDTO> GetServiceById(int id, CancellationToken cancellationToken)
    => await _repository.GetServiceById(id, cancellationToken);

    public async Task UpdateService(ServiceSubCategoryDTO model, CancellationToken cancellationToken)
    => await _repository.UpdateService(model, cancellationToken);
}
