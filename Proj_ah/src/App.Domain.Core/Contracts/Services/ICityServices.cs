using App.Domain.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Services;

public interface ICityServices
{
    Task<City> GetById(int cityId, CancellationToken cancellationToken);
    Task<List<City>> GetAll(CancellationToken cancellationToken);
}
