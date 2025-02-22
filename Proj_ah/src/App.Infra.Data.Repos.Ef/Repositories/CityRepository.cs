using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Entities.BaseEntities;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Repositories;

public class CityRepository : ICityRepository
{

    private readonly AppDbContext _context;
    public CityRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<City>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _context.Cities
           .ToListAsync(cancellationToken);

        return result;
    }

    public async Task<City> GetById(int cityId, CancellationToken cancellationToken)
    => await _context.Cities.AsNoTracking().FirstOrDefaultAsync(c => c.Id == cityId, cancellationToken);
}
