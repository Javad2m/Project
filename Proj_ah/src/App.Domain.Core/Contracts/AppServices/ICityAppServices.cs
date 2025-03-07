using App.Domain.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppServices;

public interface ICityAppServices
{
    Task<List<City>> GetAll(CancellationToken cancellationToken);
}
