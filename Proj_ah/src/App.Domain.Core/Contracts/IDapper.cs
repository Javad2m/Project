using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts;

public interface IDapper
{
    Task<List<City>> GetAllCityDapper(CancellationToken cancellationToken);

    Task<List<Category>> GetAllCategoryDapper(CancellationToken cancellationToken);
    Task<List<SubCategoryDTO>> GetAllSubCategory(CancellationToken cancellationToken);
    Task<List<ServiceSubCategoryDTO>> GetAllHomeServiceDapper(CancellationToken cancellationToken);
}
