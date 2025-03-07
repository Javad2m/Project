using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices;

public class CityAppServices : ICityAppServices
{
    private readonly ICityServices _cityServices;

    public CityAppServices(ICityServices cityServices)
    {
        _cityServices = cityServices;
    }
    public async Task<List<City>> GetAll(CancellationToken cancellationToken)
    => await _cityServices.GetAll(cancellationToken);
}
