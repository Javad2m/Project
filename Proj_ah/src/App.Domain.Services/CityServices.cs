using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services;

public class CityServices : ICityServices
{

    private readonly ICityRepository _cityRepository;

    public CityServices(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

   
    public async Task<List<City>> GetAll(CancellationToken cancellationToken)
    => await _cityRepository.GetAll(cancellationToken);

    public async Task<City> GetById(int cityId, CancellationToken cancellationToken)
    => await GetById(cityId, cancellationToken);
}
